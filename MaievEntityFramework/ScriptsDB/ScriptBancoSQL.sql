CREATE DATABASE MAIEVDATABASE
GO
USE MAIEVDATABASE
GO
CREATE TABLE TB_LE_USUARIO(
	 ID_USUARIO INT IDENTITY(1,1) PRIMARY KEY,
    DS_USUARIO VARCHAR(100) NOT NULL,
    DS_LOGIN VARCHAR(100) NOT NULL,
    DS_SENHA VARCHAR(100) NOT NULL,
    NR_IDADE INT NOT NULL,
    FL_ATIVO BIT NOT NULL,
	FL_ADMINISTRADOR BIT NOT NULL
);
GO
CREATE TABLE TB_LE_PRODUTO(
	ID_PRODUTO INT IDENTITY(1,1) PRIMARY KEY,
    DS_NOME VARCHAR(100) NOT NULL,
    VL_PRODUTO DECIMAL(18,2) NOT NULL
);
GO
CREATE TABLE TB_LE_LANCE (
    ID_LANCE INT IDENTITY(1,1) PRIMARY KEY,
    ID_USUARIO INT NOT NULL,
    ID_PRODUTO INT NOT NULL,
    VL_LANCE DECIMAL(18,2) NOT NULL,
    DT_LANCE DATETIME NOT NULL
	CONSTRAINT FK_ID_USUARIO FOREIGN KEY (ID_USUARIO)
    REFERENCES TB_LE_USUARIO(ID_USUARIO),
	CONSTRAINT FK_ID_PRODUTO FOREIGN KEY (ID_PRODUTO)
    REFERENCES TB_LE_PRODUTO(ID_PRODUTO)
);
GO
--dotnet ef dbcontext scaffold "Data Source=MAIEVDATABASE;Initial Catalog=maievdatabase;persist security info=True;user id=usr_clientemais;password=usr_clientemais;MultipleActiveResultSets=True" Microsoft.EntityFrameworkCore.SqlServer -o Models/DataBaseModels --context-dir Models/Context -d --use-database-names -f
--dotnet ef dbcontext scaffold "Data Source=den1.mssql8.gear.host;Initial Catalog=maievdatabase;persist security info=True;user id=maievdatabase;password=Ab6A4i5P_nv-;MultipleActiveResultSets=True" Microsoft.EntityFrameworkCore.SqlServer -o Models/DataBaseModels --context-dir Models/Context -d --use-database-names -f