using ExceptionMaiev;
using Maiev.DTO;
using Maiev.DTO.ResponsesDTO;
using MaievEntityFramework.Models.Context;
using MaievEntityFramework.Models.DataBaseModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Maiev.Models
{
    public class Produtos
    {
        readonly maievdatabaseContext db = null;
        public Produtos(maievdatabaseContext _db)
        {
            db = _db;
        }
        public List<ResponseProdutosDTO> Listar ()
        {
            try
            {
                List<ResponseProdutosDTO> lstProdutos = (
                                                from pr in db.TB_LE_PRODUTOs
                                                let totalLances = db.TB_LE_LANCEs.Where(X => X.ID_PRODUTO == pr.ID_PRODUTO).Count()
                                                let Maxlance = db.TB_LE_LANCEs.Where(X => X.ID_PRODUTO == pr.ID_PRODUTO).Max(x => x.VL_LANCE)
                                                select new ResponseProdutosDTO
                                                {
                                                    ID_PRODUTO = pr.ID_PRODUTO,
                                                    DS_NOME = pr.DS_NOME,
                                                    VL_PRODUTO = pr.VL_PRODUTO,
                                                    NR_LANCES = totalLances,
                                                    VL_LANCE_ATUAL = (Maxlance >0 ? Maxlance : pr.VL_PRODUTO)
                                                }
                                                ).ToList();

                return lstProdutos;

            }
            catch (Exception ex)
            {
                throw new HttpException("Erro Interno no Sistema", string.Format("Ocorrou um erro durante o cadastro. Contate o administrador. {0}", ex.Message), HttpStatusCode.InternalServerError);

            }
        }
        public void CadastrarProduto(ProdutoDTO Produto)
        {
            try
            {
                TB_LE_PRODUTO produtoObject = new TB_LE_PRODUTO();
                produtoObject.DS_NOME = Produto.DS_NOME;
                produtoObject.VL_PRODUTO = Produto.VL_PRODUTO;
                db.TB_LE_PRODUTOs.Add(produtoObject);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new HttpException("Erro Interno no Sistema", string.Format("Ocorrou um erro durante o cadastro. Contate o administrador. {0}", ex.Message), HttpStatusCode.InternalServerError);

            }
        }
        public void AtualizarProduto(ProdutoDTO Produto)
        {
            try
            {
               
                TB_LE_PRODUTO produtoObject = new TB_LE_PRODUTO();
                produtoObject.ID_PRODUTO = (int)Produto.ID_PRODUTO;
                produtoObject.DS_NOME = Produto.DS_NOME;
                produtoObject.VL_PRODUTO = Produto.VL_PRODUTO;

                db.TB_LE_PRODUTOs.Attach(produtoObject);
                db.Entry(produtoObject).State = EntityState.Modified;
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new HttpException("Erro Interno no Sistema", string.Format("Ocorrou um erro durante o cadastro. Contate o administrador. {0}", ex.Message), HttpStatusCode.InternalServerError);

            }
        }
        public void DeletarProduto(int IDProduto)
        {
            try
            {
                TB_LE_PRODUTO entity = db.TB_LE_PRODUTOs.First(c => c.ID_PRODUTO == IDProduto);
                db.TB_LE_PRODUTOs.Attach(entity);
                db.TB_LE_PRODUTOs.Remove(entity);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new HttpException("Erro Interno no Sistema", string.Format("Ocorrou um erro durante o cadastro. Contate o administrador. {0}", ex.Message), HttpStatusCode.InternalServerError);

            }
        }
    }
}
