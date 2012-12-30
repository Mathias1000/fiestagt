USE FIESTAGT
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_GT_JugadorPorPartido_GT_Jugador') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE GT_JugadorPorPartido DROP CONSTRAINT FK_GT_JugadorPorPartido_GT_Jugador
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_GT_JugadorPorPartido_GT_Partido') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE GT_JugadorPorPartido DROP CONSTRAINT FK_GT_JugadorPorPartido_GT_Partido
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_GT_Partido_GT_Guild') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE GT_Partido DROP CONSTRAINT FK_GT_Partido_GT_Guild
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_GT_Partido_GT_Guild2') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE GT_Partido DROP CONSTRAINT FK_GT_Partido_GT_Guild2
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_GT_Partido_GT_Torneo') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE GT_Partido DROP CONSTRAINT FK_GT_Partido_GT_Torneo
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_GT_PremioPorJugador_GT_Jugador') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE GT_PremioPorJugador DROP CONSTRAINT FK_GT_PremioPorJugador_GT_Jugador
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_GT_PremioPorJugador_GT_Premio') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE GT_PremioPorJugador DROP CONSTRAINT FK_GT_PremioPorJugador_GT_Premio
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_GT_PremioPorJugador_GT_Torneo') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE GT_PremioPorJugador DROP CONSTRAINT FK_GT_PremioPorJugador_GT_Torneo
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_GT_Tokens_GT_Torneo') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE GT_Tokens DROP CONSTRAINT FK_GT_Tokens_GT_Torneo
;



IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('GT_Asistencia') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE GT_Asistencia
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('GT_Guild') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE GT_Guild
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('GT_Jugador') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE GT_Jugador
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('GT_JugadorPorPartido') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE GT_JugadorPorPartido
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('GT_Partido') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE GT_Partido
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('GT_Premio') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE GT_Premio
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('GT_PremioPorJugador') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE GT_PremioPorJugador
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('GT_Tokens') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE GT_Tokens
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('GT_Torneo') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE GT_Torneo
;


CREATE TABLE GT_Asistencia ( 
	Id int identity(1,1)  NOT NULL,
	PartidoId int NOT NULL,
	JugadorId int NOT NULL,
	PuntosDeAsistencia int NOT NULL
)
;

CREATE TABLE GT_Guild ( 
	Id int identity(1,1)  NOT NULL,
	Nombre varchar(50) NOT NULL,
	Activo bit NOT NULL
)
;

CREATE TABLE GT_Jugador ( 
	Id int identity(1,1)  NOT NULL,
	Nombre varchar(50) NOT NULL,
	CantidadAsistencias int NOT NULL,
	CantidadAsistenciasHistoricas int NOT NULL,
	Activo bit NOT NULL
)
;

CREATE TABLE GT_JugadorPorPartido ( 
	Id int identity(1,1)  NOT NULL,
	PartidoId int NOT NULL,
	JugadorId int NOT NULL,
	CantidadBanderas int NOT NULL,
	PuntosDelPartido int NOT NULL,
	PuntosDeAsistencia int NOT NULL
)
;

CREATE TABLE GT_Partido ( 
	Id int identity(1,1)  NOT NULL,
	Nombre varchar(100) NULL,
	TorneoId int NOT NULL,
	Guild1Id int NOT NULL,
	Guild2Id int NOT NULL,
	PuntosGuild1 int NOT NULL,
	PuntosGuild2 int NOT NULL,
	Activo bit NOT NULL
)
;

CREATE TABLE GT_Premio ( 
	Id int identity(1,1)  NOT NULL,
	Nombre varchar(50) NOT NULL,
	ValorEnTokens int NOT NULL,
	Activo bit NOT NULL
)
;

CREATE TABLE GT_PremioPorJugador ( 
	Id int identity(1,1)  NOT NULL,
	PremioId int NOT NULL,
	TorneoId int NOT NULL,
	JugadorId int NOT NULL
)
;

CREATE TABLE GT_Tokens ( 
	Id int identity(1,1)  NOT NULL,
	TorneoId int NOT NULL,
	TokensInicio int NOT NULL,
	TokensFin int NOT NULL
)
;

CREATE TABLE GT_Torneo ( 
	Id int identity(1,1)  NOT NULL,
	Fecha datetime NOT NULL,
	Comentarios varchar(250) NULL,
	Activo bit NOT NULL
)
;


ALTER TABLE GT_Asistencia ADD CONSTRAINT PK_GT_Asistencia 
	PRIMARY KEY CLUSTERED (Id)
;

ALTER TABLE GT_Guild ADD CONSTRAINT PK_Guild 
	PRIMARY KEY CLUSTERED (Id)
;

ALTER TABLE GT_Jugador ADD CONSTRAINT PK_Jugador 
	PRIMARY KEY CLUSTERED (Id)
;

ALTER TABLE GT_JugadorPorPartido ADD CONSTRAINT PK_GT_JugadorPorPartido 
	PRIMARY KEY CLUSTERED (Id)
;

ALTER TABLE GT_Partido ADD CONSTRAINT PK_Partido 
	PRIMARY KEY CLUSTERED (Id)
;

ALTER TABLE GT_Premio ADD CONSTRAINT PK_GT_Premio 
	PRIMARY KEY CLUSTERED (Id)
;

ALTER TABLE GT_PremioPorJugador ADD CONSTRAINT PK_GT_PremioPorJugador 
	PRIMARY KEY CLUSTERED (Id)
;

ALTER TABLE GT_Tokens ADD CONSTRAINT PK_GT_Tokens 
	PRIMARY KEY CLUSTERED (Id)
;

ALTER TABLE GT_Torneo ADD CONSTRAINT PK_Torneo 
	PRIMARY KEY CLUSTERED (Id)
;


ALTER TABLE GT_Guild
	ADD CONSTRAINT UQ_Guild_Nombre UNIQUE (Nombre)
;

ALTER TABLE GT_Jugador
	ADD CONSTRAINT UQ_Jugador_Nombre UNIQUE (Nombre)
;

ALTER TABLE GT_Premio
	ADD CONSTRAINT UQ_GT_Premio_Nombre UNIQUE (Nombre)
;


ALTER TABLE GT_JugadorPorPartido ADD CONSTRAINT FK_GT_JugadorPorPartido_GT_Jugador 
	FOREIGN KEY (JugadorId) REFERENCES GT_Jugador (Id)
;

ALTER TABLE GT_JugadorPorPartido ADD CONSTRAINT FK_GT_JugadorPorPartido_GT_Partido 
	FOREIGN KEY (PartidoId) REFERENCES GT_Partido (Id)
;

ALTER TABLE GT_Partido ADD CONSTRAINT FK_GT_Partido_GT_Guild 
	FOREIGN KEY (Guild1Id) REFERENCES GT_Guild (Id)
;

ALTER TABLE GT_Partido ADD CONSTRAINT FK_GT_Partido_GT_Guild2 
	FOREIGN KEY (Guild2Id) REFERENCES GT_Guild (Id)
;

ALTER TABLE GT_Partido ADD CONSTRAINT FK_GT_Partido_GT_Torneo 
	FOREIGN KEY (TorneoId) REFERENCES GT_Torneo (Id)
;

ALTER TABLE GT_PremioPorJugador ADD CONSTRAINT FK_GT_PremioPorJugador_GT_Jugador 
	FOREIGN KEY (JugadorId) REFERENCES GT_Jugador (Id)
;

ALTER TABLE GT_PremioPorJugador ADD CONSTRAINT FK_GT_PremioPorJugador_GT_Premio 
	FOREIGN KEY (PremioId) REFERENCES GT_Premio (Id)
;

ALTER TABLE GT_PremioPorJugador ADD CONSTRAINT FK_GT_PremioPorJugador_GT_Torneo 
	FOREIGN KEY (TorneoId) REFERENCES GT_Torneo (Id)
;

ALTER TABLE GT_Tokens ADD CONSTRAINT FK_GT_Tokens_GT_Torneo 
	FOREIGN KEY (TorneoId) REFERENCES GT_Torneo (Id)
;
