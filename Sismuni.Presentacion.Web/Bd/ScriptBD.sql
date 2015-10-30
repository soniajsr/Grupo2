
create database UPC_MUNI

go

use UPC_MUNI

go


create schema Transparencia

go


 create table Transparencia.SolicitudInformacionMunicipal(NumeroSolicitud bigint identity(1,1) primary key,
														 FechaSolicitud datetime,
														 NombresSolicitante varchar(100),
														 ApellidoPaternoSolicitante varchar(100),
														 ApellidoMaternoSolicitante varchar(100),
														 TipoDocumento varchar(7) foreign key references General.Multitabla(IdMultitabla),
														 NumeroDocumento varchar(30),
														 Direccion varchar(70),
														 Telefono varchar(20),
														 Celular varchar(20),
														 Email varchar(60),
														 Modo_Envio varchar(40),
														 IdUsuarioTrabajador int foreign key references ControlPatrimonial.UsuarioTrabajador(IdUsuarioTrabajador),
														 Tipo_Informacion varchar(7),
														 Motivo_Solicitud varchar(150),
														 Observaciones varchar(300),
														 Estado varchar(7) foreign key references General.Multitabla(IdMultitabla)
														 )
go


create table Transparencia.Expediente(NumeroExpediente bigint identity(1,1) primary key ,
									  FechaExpediente datetime,
									  NumeroSolicitud bigint foreign key references Transparencia.SolicitudInformacionMunicipal(NumeroSolicitud),
									  Tipo_Expediente varchar(7) foreign key references General.Multitabla(IdMultitabla),
									  Asunto varchar(400),
									  Estado int
									  )


go

create schema General

go

create table General.GrupoTabla (IdGrupo varchar(4) primary key,
						         NombreGrupo varchar(100),
						         Estado int)

go

create table General.Multitabla (IdMultitabla varchar(7) primary key,
								 IdGrupo varchar(4) foreign key references General.GrupoTabla(IdGrupo),
								 NombreValor varchar(150),
								 DescripcionLarga varchar(100),
								 Estado int)

go


insert into General.GrupoTabla values('0001','Tipo de Documento',1)

insert into General.Multitabla values('0001001','0001','DNI','Documento Nacional de Identidad',1)
go
insert into General.Multitabla values('0001002','0001','RUC','Registro unico del Contribuyente',1)
go
insert into General.Multitabla values('0001003','0001','CARNET DE EXTRANJERÍA','Carnet de Extranjeria',1)
go

create schema ControlPatrimonial

go

CREATE TABLE [General].[Area](
	[IdArea] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Activo] [bit] NOT NULL,
	[UsuRegistro] [varchar](15) NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[UsuModifica] [varchar](15) NULL,
	[FechaModifica] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdArea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

insert into General.Area values('Administración',1,'ADMIN','2015/07/29',null,null)
insert into General.Area values('Control Patrimonial',1,'ADMIN','2015/07/29',null,null)
GO

CREATE TABLE [General].[Cargo](
	[IdCargo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Activo] [bit] NOT NULL,
	[UsuRegistro] [varchar](15) NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[UsuModifica] [varchar](15) NULL,
	[FechaModifica] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCargo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

insert into General.Cargo values('Jefe',1,'ADMIN','2015/07/29',null,null)
insert into General.Cargo values('Operario',1,'ADMIN','2015/07/29',null,null)
insert into General.Cargo values('Supervisor',1,'ADMIN','2015/07/29',null,null)
GO

CREATE TABLE [ControlPatrimonial].[Estado](
	[IdEstado] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[Activo] [bit] NOT NULL,
	[UsuRegistro] [varchar](15) NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[UsuModifica] [varchar](15) NULL,
	[FechaModifica] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEstado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

insert into ControlPatrimonial.Estado values('Registrado',1,'ADMIN','2015/07/29',null,null)
insert into ControlPatrimonial.Estado values('Pendiente',1,'ADMIN','2015/07/29',null,null)
insert into ControlPatrimonial.Estado values('Aprobado',1,'ADMIN','2015/07/29',null,null)
insert into ControlPatrimonial.Estado values('Rechazado',1,'ADMIN','2015/07/29',null,null)
insert into ControlPatrimonial.Estado values('En reparación',1,'ADMIN','2015/07/29',null,null)
insert into ControlPatrimonial.Estado values('Anulado',1,'ADMIN','2015/07/29',null,null)
GO

CREATE TABLE [ControlPatrimonial].[BienMueble](
	[IdBienMueble] [int] IDENTITY(1,1) NOT NULL,
	[IdEstado] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[UsuRegistro] [varchar](15) NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[UsuModifica] [varchar](15) NULL,
	[FechaModifica] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdBienMueble] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [ControlPatrimonial].[BienMueble]  WITH CHECK ADD FOREIGN KEY([IdEstado])
REFERENCES [ControlPatrimonial].[Estado] ([IdEstado])
GO

insert into ControlPatrimonial.BienMueble values(1,'Laptop TOSHIBA','ADMIN','2015/07/29',null,null)
insert into ControlPatrimonial.BienMueble values(1,'Smartphone SAMSUNG RPM','ADMIN','2015/07/29',null,null)
insert into ControlPatrimonial.BienMueble values(1,'Parlantes BOSS','ADMIN','2015/07/29',null,null)
GO

CREATE TABLE [ControlPatrimonial].[UsuarioTrabajador](
	[IdUsuarioTrabajador] [int] IDENTITY(1,1) NOT NULL,
	[IdArea] [int] NOT NULL,
	[IdCargo] [int] NOT NULL,
	[IdEstado] [int] NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[ApePaterno] [varchar](50) NOT NULL,
	[ApeMaterno] [varchar](50) NULL,
	[IdDocumento] [int] NOT NULL,
	[NroDocumento] [varchar](50) NOT NULL,
	[FechaNacimiento] [datetime] NOT NULL,
	[FechaIngreso] [datetime] NOT NULL,
	[FechaCese] [datetime] NULL,
	[UsuRegistro] [varchar](15) NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[UsuModifica] [varchar](15) NULL,
	[FechaModifica] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuarioTrabajador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [ControlPatrimonial].[UsuarioTrabajador]  WITH CHECK ADD FOREIGN KEY([IdArea])
REFERENCES [General].[Area] ([IdArea])
GO

ALTER TABLE [ControlPatrimonial].[UsuarioTrabajador]  WITH CHECK ADD FOREIGN KEY([IdCargo])
REFERENCES [General].[Cargo] ([IdCargo])
GO

ALTER TABLE [ControlPatrimonial].[UsuarioTrabajador]  WITH CHECK ADD FOREIGN KEY([IdEstado])
REFERENCES [ControlPatrimonial].[Estado] ([IdEstado])
GO

insert into ControlPatrimonial.UsuarioTrabajador values(2,1,1,'Juan','Perez','Sosa',1,'44599878','1972/01/30','2015/01/01',null,'ADMIN','2015/07/29',null,null)
insert into ControlPatrimonial.UsuarioTrabajador values(2,2,1,'Daniel','Ángeles','Luján',1,'78862309','1989/06/17','2015/01/01',null,'ADMIN','2015/07/29',null,null)
GO

CREATE TABLE [ControlPatrimonial].[SolicitudAsignacionBienMueble](
	[IdSolicitudAsignacion] [int] IDENTITY(1,1) NOT NULL,
	[IdEstado] [int] NOT NULL,
	[IdArea] [int] NOT NULL,
	[NroSolicitudAsignacion] [int] NOT NULL,
	[FechaSolicitudAsignacion] [datetime] NOT NULL,
	[IdUsuarioTrabajador] [int] NOT NULL,
	[UsuRegistro] [varchar](15) NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[UsuModifica] [varchar](15) NULL,
	[FechaModifica] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdSolicitudAsignacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [ControlPatrimonial].[SolicitudAsignacionBienMueble]  WITH CHECK ADD FOREIGN KEY([IdEstado])
REFERENCES [ControlPatrimonial].[Estado] ([IdEstado])
GO

ALTER TABLE [ControlPatrimonial].[SolicitudAsignacionBienMueble]  WITH CHECK ADD FOREIGN KEY([IdArea])
REFERENCES [General].[Area] ([IdArea])
GO

CREATE TABLE [ControlPatrimonial].[AsignacionBienMueble](
	[IdAsignacion] [int] IDENTITY(1,1) NOT NULL,
	[IdSolicitudAsignacion] [int] NOT NULL,
	[IdUsuarioTrabajador] [int] NOT NULL,
	[IdBienMueble] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[FechaAsignacion] [datetime] NOT NULL,
	[UsuRegistro] [varchar](15) NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[UsuModifica] [varchar](15) NULL,
	[FechaModifica] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdAsignacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [ControlPatrimonial].[AsignacionBienMueble]  WITH CHECK ADD FOREIGN KEY([IdUsuarioTrabajador])
REFERENCES [ControlPatrimonial].[UsuarioTrabajador] ([IdUsuarioTrabajador])
GO

ALTER TABLE [ControlPatrimonial].[AsignacionBienMueble]  WITH CHECK ADD FOREIGN KEY([IdBienMueble])
REFERENCES [ControlPatrimonial].[BienMueble] ([IdBienMueble])
GO

ALTER TABLE [ControlPatrimonial].[AsignacionBienMueble]  WITH CHECK ADD FOREIGN KEY([IdSolicitudAsignacion])
REFERENCES [ControlPatrimonial].[SolicitudAsignacionBienMueble] ([IdSolicitudAsignacion])
GO


alter table Transparencia.SolicitudInformacionMunicipal add TipoDocumento varchar(7),
														NumeroDocumento varchar(30),
														Direccion varchar(70),
														Telefono varchar(20),
														Celular varchar(20),
														Email varchar(60)
 
 go 

 insert into General.GrupoTabla values('0002','Tipo de Expediente',1)

 go

insert into General.Multitabla values('0002001','0002','Información Municipal','',1)
go
insert into General.Multitabla values('0002002','0002','Información de Area','',1)

insert into general.GrupoTabla values('0003','Tipo de Información Municipal',1)
go
insert into general.GrupoTabla values('0004','Modo de Envio',1)
go
insert into general.GrupoTabla values('0005','Estados de Solicitudes Municipales',1)
go

insert into General.Multitabla values('0003001','0003','Presupuestos','',1)
go
insert into General.Multitabla values('0003002','0003','Obras Públicas','',1)
go
insert into General.Multitabla values('0003003','0003','Resoluciones','',1)
go
insert into General.Multitabla values('0003004','0003','Educación','',1)
go
insert into General.Multitabla values('0003005','0003','Catastro','',1)
go
insert into General.Multitabla values('0004001','0004','Email','',1)
go
insert into General.Multitabla values('0004002','0004','Fax','',1)
go
insert into General.Multitabla values('0004003','0004','Courier','',1)
go
insert into General.Multitabla values('0005001','0005','Pendiente','',1)
go
insert into General.Multitabla values('0005002','0005','Asignada','',1)
go
insert into General.Multitabla values('0005003','0005','Aprobada','',1)
go
insert into General.Multitabla values('0005004','0005','Rechazada','',1)
go
insert into General.Multitabla values('0005005','0005','Atendida','',1)
go

-- TESORERIA Y FINANZAS

create schema TesoreriaFinanzas

go

create table TesoreriaFinanzas.ConceptoRecibo(
Codigo bigint identity(1,1) primary key,
Descripcion varchar(100)
)

create table TesoreriaFinanzas.ReciboProvisional(
NumeroRecibo bigint identity(1,1) primary key,
CodConceptoRecibo bigint foreign key references TesoreriaFinanzas.ConceptoRecibo(Codigo),
Motivo varchar(200),
Monto decimal(10,3),
FechaCreacion datetime,
FechaEnvio datetime,
CodEstado varchar(7) foreign key references General.Multitabla(IdMultitabla),
CodTrabajador int foreign key references ControlPatrimonial.UsuarioTrabajador(IdUsuarioTrabajador),
MotivoRechazo varchar(200)
)

create table TesoreriaFinanzas.MovimientoCajaChica(
CodigoMovimiento bigint identity(1,1) primary key,
FechaCreacion datetime,
FechaActualizacion datetime,
MontoMovimiento decimal(10,3),
CodTipoMovimiento varchar(7) foreign key references General.Multitabla(IdMultitabla),
CodOrigenMovimiento varchar(7) foreign key references General.Multitabla(IdMultitabla) 
)

go

create table TesoreriaFinanzas.TipoCambio(
Codigo bigint identity(1,1) primary key,
CodMoneda varchar(7) foreign key references General.Multitabla(IdMultitabla),
Fecha datetime,
Monto decimal(8,4)
)

create table TesoreriaFinanzas.ConceptoPago(
Codigo bigint identity(1,1) primary key,
Descripcion varchar(100)
)

create table TesoreriaFinanzas.FormaPago(
Codigo bigint identity(1,1) primary key,
Descripcion varchar(100)
)

create table TesoreriaFinanzas.Contribuyente(
CodContribuyente bigint identity(1,1) primary key,
Nombre varchar(200),
CodTipoDocumento varchar(7) foreign key references General.Multitabla(IdMultitabla),
NumDocumento varchar(20),
Direccion varchar(200),
TelefonoFijo varchar(20),
TelefonoMovil varchar(20),
FechaCreacion datetime
)

create table TesoreriaFinanzas.SolicitudPagoServicio(
NumSolicitudPago bigint identity(1,1) primary key,
CodContribuyente bigint foreign key references TesoreriaFinanzas.Contribuyente(CodContribuyente),
FechaSolicitud datetime,
CodConceptoPago bigint foreign key references TesoreriaFinanzas.ConceptoPago(Codigo),
Monto decimal(10,3),
Motivo varchar(200),
CodEstadoSolicitud varchar(7) foreign key references General.Multitabla(IdMultitabla)
)


create table TesoreriaFinanzas.PagoServicio(
NumeroPago bigint identity(1,1) primary key,
NumSolicitudPago bigint foreign key references TesoreriaFinanzas.SolicitudPagoServicio(NumSolicitudPago),
CodFormaPago bigint foreign key references TesoreriaFinanzas.FormaPago(Codigo),
CodTipoCambio bigint foreign key references TesoreriaFinanzas.TipoCambio(Codigo),
CodMonedaPago varchar(7) foreign key references General.Multitabla(IdMultitabla),
MontoPago decimal(10,3),
FechaPago datetime,
CodEstadoPago varchar(7) foreign key references General.Multitabla(IdMultitabla)
)


insert into General.GrupoTabla values('0006','Estados de Recibo Provsional',1)
go
insert into General.GrupoTabla values('0007','Tipo Movimiento Caja Chica',1)
go
insert into General.GrupoTabla values('0008','Origen Movimiento',1)
go
insert into General.GrupoTabla values('0009','Tipo de Moneda',1)
go
insert into General.GrupoTabla values('0010','Estado Solicitud Pago Servicio',1)
go
insert into General.GrupoTabla values('0011','Estado Pago Servicio',1)
go

insert into General.Multitabla values('0006001','0006','Aprobado','',1)
go
insert into General.Multitabla values('0006002','0006','Rechazado','',1)
go
insert into General.Multitabla values('0006003','0006','Pendiente','',1)
go
 
insert into General.Multitabla values('0007001','0007','Apertura','',1)
go
insert into General.Multitabla values('0007002','0007','Cierre','',1)
go
insert into General.Multitabla values('0007003','0007','Salida','',1)
go
insert into General.Multitabla values('0007004','0007','Ingreso','',1)
 go 

insert into General.Multitabla values('0008001','0008','Recibo Provisional','',1)
go

insert into General.Multitabla values('0009001','0009','S/.','Nuevos Soles',1)
go
insert into General.Multitabla values('0009002','0009','$','Dolares Americanos',1)
go
insert into General.Multitabla values('0009003','0009','€','Euros',1)
go
insert into General.Multitabla values('0009004','0009','£','Libras Esterlinas',1)
 go

insert into General.Multitabla values('0010001','0010','Pendiente','',1)
go
insert into General.Multitabla values('0010002','0010','Pagado','',1)
go
insert into General.Multitabla values('0010003','0010','Anulado','',1)
go

insert into General.Multitabla values('0011001','0011','Registrado','',1)
go
insert into General.Multitabla values('0011002','0011','Extornado','',1)
go

insert into TesoreriaFinanzas.ConceptoRecibo values('ALIMENTOS')
go
insert into TesoreriaFinanzas.ConceptoRecibo values('REPUESTOS IMPRESORA')
go
insert into TesoreriaFinanzas.ConceptoRecibo values('MOVILIDAD')
go

insert into TesoreriaFinanzas.TipoCambio values('0009002',GETDATE(),3.195);
go
insert into TesoreriaFinanzas.TipoCambio values('0009003',GETDATE(),3.5013);
go

insert into TesoreriaFinanzas.FormaPago values('Efectivo');
go
insert into TesoreriaFinanzas.FormaPago values('Cheque');
go

insert into TesoreriaFinanzas.ConceptoPago values('Deuda Tributaria');
go
insert into TesoreriaFinanzas.ConceptoPago values('Sevicio Municipal');
go

insert into TesoreriaFinanzas.Contribuyente values('Johan Asenjo','0001001','43430001',null,null,null,GETDATE());
go

insert into TesoreriaFinanzas.ReciboProvisional values(1,'HAMBRE',20,GETDATE(),GETDATE(),'0006003',NULL,NULL)
go
insert into TesoreriaFinanzas.ReciboProvisional values(2,'HAMBRE2',30,GETDATE(),GETDATE(),'0006003',NULL,NULL)
go
insert into TesoreriaFinanzas.ReciboProvisional values(2,'AMANECIDA',40,GETDATE(),GETDATE(),'0006003',NULL,NULL)
insert into General.Multitabla values('0004002','0004','Courier','',1)
go
insert into TesoreriaFinanzas.ReciboProvisional values(3,'AMANECIDA',50,GETDATE(),GETDATE(),'0006003',NULL,NULL)
go
insert into TesoreriaFinanzas.ReciboProvisional values(3,'AMANECIDA',40,GETDATE(),GETDATE(),'0006003',NULL,NULL)
go


insert into TesoreriaFinanzas.SolicitudPagoServicio values(1,GETDATE(),1,1000.50,'PAGOS ATRASADOS','0010001');
go
insert into TesoreriaFinanzas.SolicitudPagoServicio values(1,GETDATE(),1,100.50,'PAGOS ATRASADOS','0010001');
go
insert into TesoreriaFinanzas.SolicitudPagoServicio values(1,GETDATE(),2,100.50,'PERMISOS','0010001');
go