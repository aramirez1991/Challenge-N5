USE [test]
GO

/****** Object:  Table [dbo].[Permisos]    Script Date: 10/25/2022 12:08:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Permisos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombreEmpleado] [text] NOT NULL,
	[ApellidoEmpleado] [text] NOT NULL,
	[TipoPermiso] [int] NOT NULL,
	[FechaPermiso] [date] NOT NULL,
 CONSTRAINT [PK_Permisos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Permisos]  WITH CHECK ADD  CONSTRAINT [FK_Id_Permiso_Tipo_1] FOREIGN KEY([TipoPermiso])
REFERENCES [dbo].[TipoPermisos] ([Id])
GO

ALTER TABLE [dbo].[Permisos] CHECK CONSTRAINT [FK_Id_Permiso_Tipo_1]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id de permiso' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Permisos', @level2type=N'COLUMN',@level2name=N'Id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de empleado' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Permisos', @level2type=N'COLUMN',@level2name=N'NombreEmpleado'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Apellido de empleado' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Permisos', @level2type=N'COLUMN',@level2name=N'ApellidoEmpleado'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id de tipo de permiso' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Permisos', @level2type=N'COLUMN',@level2name=N'TipoPermiso'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de registro permiso' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Permisos', @level2type=N'COLUMN',@level2name=N'FechaPermiso'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Relacion permisos y tipo de permiso' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Permisos', @level2type=N'CONSTRAINT',@level2name=N'FK_Id_Permiso_Tipo_1'
GO


