using ExceptionMaiev;
using Maiev.DTO;
using Maiev.DTO.ResponsesDTO;
using MaievEntityFramework.Models.Context;
using MaievEntityFramework.Models.DataBaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Maiev.Models
{
    public class Leilao
    {
        maievdatabaseContext db = new maievdatabaseContext();

        public void CadastrarLance(LanceDTO lance, ClaimsIdentity identity)
        {
            try
            {
                decimal LanceAtual = db.TB_LE_LANCEs.Where(x => x.ID_PRODUTO == lance.ID_PRODUTO).OrderByDescending(x=> x.VL_LANCE).Select(x => x.VL_LANCE).FirstOrDefault();

                decimal vlProduto = db.TB_LE_PRODUTOs.Where(x => x.ID_PRODUTO == lance.ID_PRODUTO).Max(x => x.VL_PRODUTO);

                if (LanceAtual >= lance.VL_LANCE)
                    throw new HttpException("Erro ao Efetuar Lance", "Não foi possivel fazer um lance neste produto pois o valor e Igual ou inferior ao maior lance atual ja feito", HttpStatusCode.BadRequest);

                if (vlProduto >= lance.VL_LANCE)
                    throw new HttpException("Erro ao Efetuar Lance", "Não foi possivel fazer um lance neste produto pois o valor e Igual ou inferior ao valor do Produto", HttpStatusCode.BadRequest);

                List<Claim> claim = identity.Claims.ToList();

                TB_LE_LANCE LanceObject = new TB_LE_LANCE();
                LanceObject.ID_PRODUTO = lance.ID_PRODUTO;
                LanceObject.ID_USUARIO = int.Parse(claim[0].Value);
                LanceObject.VL_LANCE = lance.VL_LANCE;
                LanceObject.DT_LANCE = DateTime.Now;
                db.TB_LE_LANCEs.Add(LanceObject);
                db.SaveChanges();
            }
            catch (HttpException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new HttpException("Erro Interno no Sistema", string.Format("Ocorrou um erro durante o cadastro. Contate o administrador. {0}", ex.Message), HttpStatusCode.InternalServerError);

            }
        }
    
        public List<LeilaoProdutoDTO> ListarLances(int ID_PRODUTO)
        {
            try
            {
                List<LeilaoProdutoDTO> Leilao = (from lc in db.TB_LE_LANCEs
                    join pr in db.TB_LE_PRODUTOs on lc.ID_PRODUTO equals pr.ID_PRODUTO
                    join us in db.TB_LE_USUARIOs on lc.ID_USUARIO equals us.ID_USUARIO
                    where lc.ID_PRODUTO == ID_PRODUTO
                    orderby lc.VL_LANCE descending
                    select new LeilaoProdutoDTO
                        {
                            ID_LANCE = lc.ID_LANCE,
                            DS_PRODUTO = pr.DS_NOME,
                            DS_USUARIO = us.DS_USUARIO,
                            DT_LANCE = lc.DT_LANCE,
                            VL_LANCE = lc.VL_LANCE
                        }
                    ).ToList();
                return Leilao;

            }
            catch (HttpException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new HttpException("Erro Interno no Sistema", string.Format("Ocorrou um erro durante a listagem dos Lances. Contate o administrador. {0}", ex.Message), HttpStatusCode.InternalServerError);

            }
        }
    }
}
