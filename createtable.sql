USE [xEasyApp]
GO
/****** Object:  Table [dbo].[UserInfos]    Script Date: 06/27/2011 21:37:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserInfos](
	[UserUID] [varchar](20) NOT NULL,
	[FullName] [nvarchar](200) NOT NULL,
	[Password] [varchar](200) NOT NULL,
	[OrgCode] [varchar](50) NOT NULL,
	[OrgName] [nvarchar](200) NULL,
	[IsManager] [bit] NOT NULL,
	[IsSystem] [bit] NOT NULL,
	[Sequence] [int] NOT NULL,
	[AccountState] [tinyint] NOT NULL,
	[LastUpdateUserUID] [varchar](50) NOT NULL,
	[LastUpdateUserName] [nvarchar](100) NOT NULL,
	[LastUpdateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_USERINFOS] PRIMARY KEY CLUSTERED 
(
	[UserUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�û���ʶ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfos', @level2type=N'COLUMN',@level2name=N'UserUID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�û�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfos', @level2type=N'COLUMN',@level2name=N'FullName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��¼����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfos', @level2type=N'COLUMN',@level2name=N'Password'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfos', @level2type=N'COLUMN',@level2name=N'OrgCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfos', @level2type=N'COLUMN',@level2name=N'OrgName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ��鳤' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfos', @level2type=N'COLUMN',@level2name=N'IsManager'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfos', @level2type=N'COLUMN',@level2name=N'Sequence'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˺�״̬
   0	����
   1	ͣ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfos', @level2type=N'COLUMN',@level2name=N'AccountState'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���һ�θ����û���ʶ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfos', @level2type=N'COLUMN',@level2name=N'LastUpdateUserUID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���һ�θ����û�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfos', @level2type=N'COLUMN',@level2name=N'LastUpdateUserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���һ�θ���ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfos', @level2type=N'COLUMN',@level2name=N'LastUpdateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�û�������Ϣ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfos'
GO
INSERT [dbo].[UserInfos] ([UserUID], [FullName], [Password], [OrgCode], [OrgName], [IsManager], [IsSystem], [Sequence], [AccountState], [LastUpdateUserUID], [LastUpdateUserName], [LastUpdateTime]) VALUES (N'0011', N'������', N'96E79218965EB72C92A549DD5A330112', N'03', N'����', 1, 0, 2, 1, N'admin', N'����Ա', CAST(0x00009F0D018A4F27 AS DateTime))
INSERT [dbo].[UserInfos] ([UserUID], [FullName], [Password], [OrgCode], [OrgName], [IsManager], [IsSystem], [Sequence], [AccountState], [LastUpdateUserUID], [LastUpdateUserName], [LastUpdateTime]) VALUES (N'admin', N'����Ա', N'E10ADC3949BA59ABBE56E057F20F883E', N'-1', N'ϵͳ����', 0, 1, 0, 0, N'admin', N'����Ա', CAST(0x00009EF700000000 AS DateTime))
INSERT [dbo].[UserInfos] ([UserUID], [FullName], [Password], [OrgCode], [OrgName], [IsManager], [IsSystem], [Sequence], [AccountState], [LastUpdateUserUID], [LastUpdateUserName], [LastUpdateTime]) VALUES (N'huanger', N'�ƶ�', N'E10ADC3949BA59ABBE56E057F20F883E', N'01', N'ҵ��һ��', 0, 0, 99, 1, N'admin', N'����Ա', CAST(0x00009F0D01889430 AS DateTime))
INSERT [dbo].[UserInfos] ([UserUID], [FullName], [Password], [OrgCode], [OrgName], [IsManager], [IsSystem], [Sequence], [AccountState], [LastUpdateUserUID], [LastUpdateUserName], [LastUpdateTime]) VALUES (N'test', N'������Ա', N'C33367701511B4F6020EC61DED352059', N'01', N'���ù���', 1, 0, 99, 1, N'admin', N'����Ա', CAST(0x00009F0D0188B0F5 AS DateTime))
INSERT [dbo].[UserInfos] ([UserUID], [FullName], [Password], [OrgCode], [OrgName], [IsManager], [IsSystem], [Sequence], [AccountState], [LastUpdateUserUID], [LastUpdateUserName], [LastUpdateTime]) VALUES (N'wangsm', N'������', N'C4CA4238A0B923820DCC509A6F75849B', N'02', N'��Ϣ����', 1, 0, 0, 1, N'admin', N'����Ա', CAST(0x00009F0D018A5BC1 AS DateTime))
/****** Object:  Table [dbo].[RoleInfos]    Script Date: 06/27/2011 21:37:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RoleInfos](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleCode] [varchar](50) NOT NULL,
	[RoleName] [nvarchar](100) NOT NULL,
	[Remark] [nvarchar](1000) NULL,
	[ParentID] [int] NULL,
	[IsSystem] [bit] NOT NULL,
	[RolePath] [varchar](4000) NULL,
	[LastUpdateUserUID] [varchar](50) NOT NULL,
	[LastUpdateUserName] [nvarchar](100) NOT NULL,
	[LastUpdateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_ROLEINFOS] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ɫID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleInfos', @level2type=N'COLUMN',@level2name=N'RoleID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ɫ��ʶ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleInfos', @level2type=N'COLUMN',@level2name=N'RoleCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ɫ����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleInfos', @level2type=N'COLUMN',@level2name=N'RoleName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N' ��ɫ˵��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleInfos', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ɫID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleInfos', @level2type=N'COLUMN',@level2name=N'ParentID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ�ϵͳ��ɫ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleInfos', @level2type=N'COLUMN',@level2name=N'IsSystem'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ɫ·��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleInfos', @level2type=N'COLUMN',@level2name=N'RolePath'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���һ�θ����û���ʶ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleInfos', @level2type=N'COLUMN',@level2name=N'LastUpdateUserUID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���һ�θ����û�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleInfos', @level2type=N'COLUMN',@level2name=N'LastUpdateUserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���һ�θ���ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleInfos', @level2type=N'COLUMN',@level2name=N'LastUpdateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ɫ��Ϣ��
   ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleInfos'
GO
SET IDENTITY_INSERT [dbo].[RoleInfos] ON
INSERT [dbo].[RoleInfos] ([RoleID], [RoleCode], [RoleName], [Remark], [ParentID], [IsSystem], [RolePath], [LastUpdateUserUID], [LastUpdateUserName], [LastUpdateTime]) VALUES (1, N'admin', N'ϵͳ����Ա', N'ϵͳ����Ա', NULL, 1, N'', N'admin', N'����Ա', CAST(0x00009EFD00000000 AS DateTime))
INSERT [dbo].[RoleInfos] ([RoleID], [RoleCode], [RoleName], [Remark], [ParentID], [IsSystem], [RolePath], [LastUpdateUserUID], [LastUpdateUserName], [LastUpdateTime]) VALUES (2, N'everyone', N'�����˽�ɫ', N'ϵͳ�е�������', NULL, 1, N'', N'admin', N'����Ա', CAST(0x00009EFD00000000 AS DateTime))
INSERT [dbo].[RoleInfos] ([RoleID], [RoleCode], [RoleName], [Remark], [ParentID], [IsSystem], [RolePath], [LastUpdateUserUID], [LastUpdateUserName], [LastUpdateTime]) VALUES (3, N'default', N'Ĭ�ϵĸ���ɫ', N'Ĭ�ϵĸ���ɫ', NULL, 0, N'', N'admin', N'����Ա', CAST(0x00009EFD016F8185 AS DateTime))
INSERT [dbo].[RoleInfos] ([RoleID], [RoleCode], [RoleName], [Remark], [ParentID], [IsSystem], [RolePath], [LastUpdateUserUID], [LastUpdateUserName], [LastUpdateTime]) VALUES (4, N'test1', N'���Խ�ɫ', N'���Խ�ɫ', 3, 0, N'.3.', N'admin', N'����Ա', CAST(0x00009EFD016F9A97 AS DateTime))
SET IDENTITY_INSERT [dbo].[RoleInfos] OFF
/****** Object:  Table [dbo].[Privileges]    Script Date: 06/27/2011 21:37:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Privileges](
	[PrivilegeCode] [varchar](20) NOT NULL,
	[PrivilegeName] [nvarchar](100) NOT NULL,
	[PrivilegeType] [tinyint] NOT NULL,
	[Remark] [nvarchar](1000) NULL,
	[ParentID] [varchar](20) NULL,
	[Uri] [varchar](2000) NULL,
	[Sequence] [int] NOT NULL,
	[LastUpdateUserUID] [varchar](50) NOT NULL,
	[LastUpdateUserName] [nvarchar](100) NOT NULL,
	[LastUpdateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_PRIVILEGES] PRIMARY KEY CLUSTERED 
(
	[PrivilegeCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ȩ�ޱ�ʶ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Privileges', @level2type=N'COLUMN',@level2name=N'PrivilegeCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ȩ������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Privileges', @level2type=N'COLUMN',@level2name=N'PrivilegeName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ȩ������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Privileges', @level2type=N'COLUMN',@level2name=N'PrivilegeType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��Ȩ�ޱ�ʶ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Privileges', @level2type=N'COLUMN',@level2name=N'ParentID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�˵�Ȩ�޶�Ӧ�����ӵ�ַ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Privileges', @level2type=N'COLUMN',@level2name=N'Uri'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Privileges', @level2type=N'COLUMN',@level2name=N'Sequence'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���һ�θ����û���ʶ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Privileges', @level2type=N'COLUMN',@level2name=N'LastUpdateUserUID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���һ�θ����û�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Privileges', @level2type=N'COLUMN',@level2name=N'LastUpdateUserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���һ�θ���ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Privileges', @level2type=N'COLUMN',@level2name=N'LastUpdateTime'
GO
INSERT [dbo].[Privileges] ([PrivilegeCode], [PrivilegeName], [PrivilegeType], [Remark], [ParentID], [Uri], [Sequence], [LastUpdateUserUID], [LastUpdateUserName], [LastUpdateTime]) VALUES (N'10000', N'ϵͳ����', 2, N'12121', NULL, NULL, 999, N'admin', N'����Ա', CAST(0x00009F0D01489443 AS DateTime))
INSERT [dbo].[Privileges] ([PrivilegeCode], [PrivilegeName], [PrivilegeType], [Remark], [ParentID], [Uri], [Sequence], [LastUpdateUserUID], [LastUpdateUserName], [LastUpdateTime]) VALUES (N'10010', N'�û�����', 2, NULL, N'10000', N'/SysManage/UserList', 10010, N'wangsm', N'������', CAST(0x00009F0E00AD1A77 AS DateTime))
INSERT [dbo].[Privileges] ([PrivilegeCode], [PrivilegeName], [PrivilegeType], [Remark], [ParentID], [Uri], [Sequence], [LastUpdateUserUID], [LastUpdateUserName], [LastUpdateTime]) VALUES (N'10020', N'���Ź���', 2, NULL, N'10000', N'/SysManage/OrginfoList', 10020, N'wangsm', N'������', CAST(0x00009F0E00AD24D0 AS DateTime))
INSERT [dbo].[Privileges] ([PrivilegeCode], [PrivilegeName], [PrivilegeType], [Remark], [ParentID], [Uri], [Sequence], [LastUpdateUserUID], [LastUpdateUserName], [LastUpdateTime]) VALUES (N'10030', N'��ɫ����', 2, NULL, N'10000', N'/SysManage/RoleInfoList', 10030, N'wangsm', N'������', CAST(0x00009F0E00AD2030 AS DateTime))
INSERT [dbo].[Privileges] ([PrivilegeCode], [PrivilegeName], [PrivilegeType], [Remark], [ParentID], [Uri], [Sequence], [LastUpdateUserUID], [LastUpdateUserName], [LastUpdateTime]) VALUES (N'10040', N'Ȩ�޹���', 2, NULL, N'10000', N'/SysManage/PrivilegeList', 10040, N'wangsm', N'������', CAST(0x00009F0E00AD14B1 AS DateTime))
INSERT [dbo].[Privileges] ([PrivilegeCode], [PrivilegeName], [PrivilegeType], [Remark], [ParentID], [Uri], [Sequence], [LastUpdateUserUID], [LastUpdateUserName], [LastUpdateTime]) VALUES (N'10050', N'��Ȩ����', 2, NULL, N'10000', N'/SysManage/QueryAuthorization', 10050, N'wangsm', N'������', CAST(0x00009F0E00AD2A89 AS DateTime))
INSERT [dbo].[Privileges] ([PrivilegeCode], [PrivilegeName], [PrivilegeType], [Remark], [ParentID], [Uri], [Sequence], [LastUpdateUserUID], [LastUpdateUserName], [LastUpdateTime]) VALUES (N'10060', N'�ֵ����', 2, NULL, N'10000', N'/SysManage/DictInfoList', 10060, N'wangsm', N'������', CAST(0x00009F0E00AD2F53 AS DateTime))
INSERT [dbo].[Privileges] ([PrivilegeCode], [PrivilegeName], [PrivilegeType], [Remark], [ParentID], [Uri], [Sequence], [LastUpdateUserUID], [LastUpdateUserName], [LastUpdateTime]) VALUES (N'10070', N'������־', 2, NULL, N'10000', N'/SysManage/LogList', 10070, N'wangsm', N'������', CAST(0x00009F0E00AD3419 AS DateTime))
/****** Object:  Table [dbo].[Organizations]    Script Date: 06/27/2011 21:37:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Organizations](
	[OrgCode] [varchar](50) NOT NULL,
	[OrgName] [nvarchar](200) NOT NULL,
	[ParentCode] [varchar](50) NULL,
	[Path] [varchar](2000) NOT NULL,
	[Remark] [nvarchar](2000) NULL,
	[Sequence] [int] NOT NULL,
	[OrgType] [tinyint] NOT NULL,
	[UnitName] [nvarchar](200) NULL,
	[UnitCode] [varchar](50) NULL,
	[LastUpdateUserUID] [varchar](50) NOT NULL,
	[LastUpdateUserName] [nvarchar](100) NOT NULL,
	[LastUpdateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_ORGANIZATIONS] PRIMARY KEY CLUSTERED 
(
	[OrgCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��֯��ʶ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organizations', @level2type=N'COLUMN',@level2name=N'OrgCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��֯����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organizations', @level2type=N'COLUMN',@level2name=N'OrgName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��������ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organizations', @level2type=N'COLUMN',@level2name=N'ParentCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��֯����·��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organizations', @level2type=N'COLUMN',@level2name=N'Path'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ע' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organizations', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organizations', @level2type=N'COLUMN',@level2name=N'Sequence'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��֯����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organizations', @level2type=N'COLUMN',@level2name=N'OrgType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��λ��ʶ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organizations', @level2type=N'COLUMN',@level2name=N'UnitName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��λ����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organizations', @level2type=N'COLUMN',@level2name=N'UnitCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���һ�θ����û���ʶ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organizations', @level2type=N'COLUMN',@level2name=N'LastUpdateUserUID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���һ�θ����û�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organizations', @level2type=N'COLUMN',@level2name=N'LastUpdateUserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���һ�θ���ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organizations', @level2type=N'COLUMN',@level2name=N'LastUpdateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��֯��Ϣ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organizations'
GO
INSERT [dbo].[Organizations] ([OrgCode], [OrgName], [ParentCode], [Path], [Remark], [Sequence], [OrgType], [UnitName], [UnitCode], [LastUpdateUserUID], [LastUpdateUserName], [LastUpdateTime]) VALUES (N'00', N'Caso��˾', N'-1', N'.-1.', N'��֯��', 0, 0, N'Caso��˾', N'00', N'admin', N'����Ա', CAST(0x00009EE000000000 AS DateTime))
INSERT [dbo].[Organizations] ([OrgCode], [OrgName], [ParentCode], [Path], [Remark], [Sequence], [OrgType], [UnitName], [UnitCode], [LastUpdateUserUID], [LastUpdateUserName], [LastUpdateTime]) VALUES (N'01', N'ҵ��һ��', N'00', N'.-1.00.', NULL, 10, 1, N'Caso��˾', N'00', N'admin', N'����Ա', CAST(0x00009F06009E3406 AS DateTime))
INSERT [dbo].[Organizations] ([OrgCode], [OrgName], [ParentCode], [Path], [Remark], [Sequence], [OrgType], [UnitName], [UnitCode], [LastUpdateUserUID], [LastUpdateUserName], [LastUpdateTime]) VALUES (N'02', N'��Ϣ����', N'00', N'.-1.00.', N'��Ϣ����', 99, 1, N'Caso��˾', N'00', N'admin', N'����Ա', CAST(0x00009F06009E6201 AS DateTime))
INSERT [dbo].[Organizations] ([OrgCode], [OrgName], [ParentCode], [Path], [Remark], [Sequence], [OrgType], [UnitName], [UnitCode], [LastUpdateUserUID], [LastUpdateUserName], [LastUpdateTime]) VALUES (N'03', N'����', N'00', N'.-1.00.', NULL, 30, 1, N'Caso��˾', N'00', N'admin', N'����Ա', CAST(0x00009F06009E6C00 AS DateTime))
/****** Object:  Table [dbo].[Logs]    Script Date: 06/27/2011 21:37:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Logs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[OperateCode] [varchar](100) NOT NULL,
	[LogType] [tinyint] NOT NULL,
	[OperateUID] [varchar](20) NOT NULL,
	[OperateName] [nvarchar](200) NOT NULL,
	[IPAddress] [varchar](15) NOT NULL,
	[OperateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_LOGS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������ʶ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Logs', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Logs', @level2type=N'COLUMN',@level2name=N'Content'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������ʶ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Logs', @level2type=N'COLUMN',@level2name=N'OperateCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��־����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Logs', @level2type=N'COLUMN',@level2name=N'LogType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������Ա��ʶ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Logs', @level2type=N'COLUMN',@level2name=N'OperateUID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������Ա����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Logs', @level2type=N'COLUMN',@level2name=N'OperateName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Logs', @level2type=N'COLUMN',@level2name=N'IPAddress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Logs', @level2type=N'COLUMN',@level2name=N'OperateTime'
GO

/****** Object:  UserDefinedFunction [dbo].[fn_split]    Script Date: 06/27/2011 21:37:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_split] (
@str_in  VARCHAR(8000),
@separator VARCHAR(4) )
RETURNS @strtable TABLE (item  VARCHAR(8000))
AS
BEGIN

DECLARE
 @Occurrences INT,
 @Counter INT,
 @tmpStr VARCHAR(8000)

 SET @Counter = 0
        IF SUBSTRING(@str_in,LEN(@str_in),1) <> @separator 
              SET @str_in = @str_in + @separator

 SET @Occurrences = (DATALENGTH(REPLACE(@str_in,@separator,@separator+'#')) -  DATALENGTH(@str_in))/ DATALENGTH(@separator)
 SET @tmpStr = @str_in

 WHILE @Counter <= @Occurrences 
 BEGIN
  SET @Counter = @Counter + 1
  INSERT INTO @strtable
  valueS ( SUBSTRING(@tmpStr,1,CHARINDEX(@separator,@tmpStr)-1))

  SET @tmpStr = SUBSTRING(@tmpStr,CHARINDEX(@separator,@tmpStr)+1,8000)
  
  IF DATALENGTH(@tmpStr) = 0
   BREAK
  
 END
 RETURN 
END
GO
/****** Object:  Table [dbo].[DictInfos]    Script Date: 06/27/2011 21:37:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DictInfos](
	[DictID] [int] IDENTITY(1,1) NOT NULL,
	[DictName] [varchar](100) NOT NULL,
	[DictCode] [varchar](50) NOT NULL,
	[IsSystem] [bit] NOT NULL,
	[ParentID] [int] NULL,
	[Sequence] [int] NULL,
	[Remark] [varchar](200) NULL,
 CONSTRAINT [PK_DICTINFOS] PRIMARY KEY NONCLUSTERED 
(
	[DictID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֵ�Ŀ¼ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DictInfos', @level2type=N'COLUMN',@level2name=N'DictID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ŀ¼����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DictInfos', @level2type=N'COLUMN',@level2name=N'DictName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ŀ¼����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DictInfos', @level2type=N'COLUMN',@level2name=N'DictCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ�ϵͳ�ֵ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DictInfos', @level2type=N'COLUMN',@level2name=N'IsSystem'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DictInfos', @level2type=N'COLUMN',@level2name=N'ParentID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֶ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DictInfos', @level2type=N'COLUMN',@level2name=N'Sequence'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ע' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DictInfos', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ֵ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DictInfos'
GO
SET IDENTITY_INSERT [dbo].[DictInfos] ON
INSERT [dbo].[DictInfos] ([DictID], [DictName], [DictCode], [IsSystem], [ParentID], [Sequence], [Remark]) VALUES (1, N'�Ա�', N'Gender', 0, 0, 10, N'�Ա�')
INSERT [dbo].[DictInfos] ([DictID], [DictName], [DictCode], [IsSystem], [ParentID], [Sequence], [Remark]) VALUES (2, N'ѧ��', N'Education', 0, 0, 20, NULL)
INSERT [dbo].[DictInfos] ([DictID], [DictName], [DictCode], [IsSystem], [ParentID], [Sequence], [Remark]) VALUES (3, N'Сѧ', N'0', 0, 2, 10, NULL)
INSERT [dbo].[DictInfos] ([DictID], [DictName], [DictCode], [IsSystem], [ParentID], [Sequence], [Remark]) VALUES (4, N'��', N'1', 0, 1, 10, NULL)
INSERT [dbo].[DictInfos] ([DictID], [DictName], [DictCode], [IsSystem], [ParentID], [Sequence], [Remark]) VALUES (5, N'Ů', N'0', 0, 1, 20, NULL)
INSERT [dbo].[DictInfos] ([DictID], [DictName], [DictCode], [IsSystem], [ParentID], [Sequence], [Remark]) VALUES (6, N'δ֪', N'9', 0, 1, 90, NULL)
SET IDENTITY_INSERT [dbo].[DictInfos] OFF
/****** Object:  StoredProcedure [dbo].[SP_PAGESELECT]    Script Date: 06/27/2011 21:37:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<wangshaoming>
-- Create date: <2008-12-12>
-- Description:	<��ҳ�洢����>
-- =============================================
CREATE PROCEDURE [dbo].[SP_PAGESELECT]
	@SQLPARAMS nvarchar(2000)='', --��ѯ����
	@PAGESIZE int=20,--ÿҳ�ļ�¼��
	@PAGEINDEX int=0, --�ڼ�ҳ,Ĭ�ϵ�һҳ
	@SQLTABLE varchar(5000),--Ҫ��ѯ�ı����ͼ,Ҳ����һ��sql���
	@SQLCOLUMNS varchar(4000),--��ѯ���ֶ�
	@SQLPK varchar(50),--���� 
	@SQLORDER varchar(200),--����
	@Count int=-1 output
AS
BEGIN	
	SET NOCOUNT ON;
	DECLARE @PAGELOWERBOUND INT 
	DECLARE @PAGEUPPERBOUND INT
	DECLARE @SQLSTR nvarchar(4000)
	--��ȡ��¼��
	IF @PAGEINDEX=0  --�ɸ���ʵ��Ҫ���޸�����,��������ǻ�ȡ��¼��
	BEGIN
	set @SQLSTR=N'select @sCount=count(1) FROM '+@SQLTABLE+' WHERE 1=1'+@SQLPARAMS
	Exec sp_executesql @sqlstr,N'@sCount int outPut',@Count output
	END
	ELSE
	BEGIN
		SET @COUNT =-1 
	END


	SET @PAGELOWERBOUND= @PAGEINDEX *@PAGESIZE+1
	SET @PAGEUPPERBOUND = @PAGELOWERBOUND +@PAGESIZE-1
	IF @SQLORDER=''
	BEGIN
		SET @SQLORDER='ORDER BY '+@SQLPK
	END
	
	
	SET @SQLSTR=N'SELECT * FROM (select '+@SQLCOLUMNS+',ROW_NUMBER() Over('+@SQLORDER+') as PAGESELECT_rowNum FROM '+@SQLTABLE+' WHERE 1=1'+@SQLPARAMS+ ') as PAGESELECT_TABLE
				where PAGESELECT_rowNum between '+STR(@PAGELOWERBOUND)+' and '+STR(@PAGEUPPERBOUND)+' '


	Exec sp_executesql @SQLSTR

END
GO
/****** Object:  Table [dbo].[RoleUserRelation]    Script Date: 06/27/2011 21:37:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RoleUserRelation](
	[RoleID] [int] NOT NULL,
	[UserUID] [varchar](20) NOT NULL,
	[LastUpdateUserUID] [varchar](50) NOT NULL,
	[LastUpdateUserName] [nvarchar](100) NOT NULL,
	[LastUpdateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_ROLEUSERRELATION] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC,
	[UserUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ɫID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleUserRelation', @level2type=N'COLUMN',@level2name=N'RoleID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�û���ʶ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleUserRelation', @level2type=N'COLUMN',@level2name=N'UserUID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���һ�θ����û���ʶ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleUserRelation', @level2type=N'COLUMN',@level2name=N'LastUpdateUserUID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���һ�θ����û�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleUserRelation', @level2type=N'COLUMN',@level2name=N'LastUpdateUserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���һ�θ���ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleUserRelation', @level2type=N'COLUMN',@level2name=N'LastUpdateTime'
GO
INSERT [dbo].[RoleUserRelation] ([RoleID], [UserUID], [LastUpdateUserUID], [LastUpdateUserName], [LastUpdateTime]) VALUES (1, N'admin', N'admin', N'����Ա', CAST(0x00009EFD00000000 AS DateTime))
INSERT [dbo].[RoleUserRelation] ([RoleID], [UserUID], [LastUpdateUserUID], [LastUpdateUserName], [LastUpdateTime]) VALUES (2, N'admin', N'admin', N'����Ա', CAST(0x00009EFD00000000 AS DateTime))
INSERT [dbo].[RoleUserRelation] ([RoleID], [UserUID], [LastUpdateUserUID], [LastUpdateUserName], [LastUpdateTime]) VALUES (2, N'test', N'admin', N'����Ա', CAST(0x00009F0D00D0955C AS DateTime))
INSERT [dbo].[RoleUserRelation] ([RoleID], [UserUID], [LastUpdateUserUID], [LastUpdateUserName], [LastUpdateTime]) VALUES (2, N'wangsm', N'admin', N'����Ա', CAST(0x00009F0D00D0955C AS DateTime))
INSERT [dbo].[RoleUserRelation] ([RoleID], [UserUID], [LastUpdateUserUID], [LastUpdateUserName], [LastUpdateTime]) VALUES (3, N'wangsm', N'admin', N'����Ա', CAST(0x00009F0700B97BCA AS DateTime))
/****** Object:  Table [dbo].[RolePrivilegeRelation]    Script Date: 06/27/2011 21:37:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RolePrivilegeRelation](
	[RoleID] [int] NOT NULL,
	[PrivilegeCode] [varchar](20) NOT NULL,
	[LastUpdateUserUID] [varchar](50) NOT NULL,
	[LastUpdateUserName] [nvarchar](100) NOT NULL,
	[LastUpdateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_ROLEPRIVILEGERELATION] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC,
	[PrivilegeCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ɫID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RolePrivilegeRelation', @level2type=N'COLUMN',@level2name=N'RoleID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ȩ�ޱ�ʶ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RolePrivilegeRelation', @level2type=N'COLUMN',@level2name=N'PrivilegeCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���һ�θ����û���ʶ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RolePrivilegeRelation', @level2type=N'COLUMN',@level2name=N'LastUpdateUserUID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���һ�θ����û�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RolePrivilegeRelation', @level2type=N'COLUMN',@level2name=N'LastUpdateUserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���һ�θ���ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RolePrivilegeRelation', @level2type=N'COLUMN',@level2name=N'LastUpdateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ɫȨ�޹�ϵ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RolePrivilegeRelation'
GO
INSERT [dbo].[RolePrivilegeRelation] ([RoleID], [PrivilegeCode], [LastUpdateUserUID], [LastUpdateUserName], [LastUpdateTime]) VALUES (3, N'10000', N'admin', N'����Ա', CAST(0x00009F0E00CBA7E6 AS DateTime))
INSERT [dbo].[RolePrivilegeRelation] ([RoleID], [PrivilegeCode], [LastUpdateUserUID], [LastUpdateUserName], [LastUpdateTime]) VALUES (3, N'10010', N'admin', N'����Ա', CAST(0x00009F0E00CBA7E6 AS DateTime))
INSERT [dbo].[RolePrivilegeRelation] ([RoleID], [PrivilegeCode], [LastUpdateUserUID], [LastUpdateUserName], [LastUpdateTime]) VALUES (3, N'10020', N'admin', N'����Ա', CAST(0x00009F0E00CBA7E6 AS DateTime))
INSERT [dbo].[RolePrivilegeRelation] ([RoleID], [PrivilegeCode], [LastUpdateUserUID], [LastUpdateUserName], [LastUpdateTime]) VALUES (3, N'10030', N'admin', N'����Ա', CAST(0x00009F0E00CBA7E6 AS DateTime))
INSERT [dbo].[RolePrivilegeRelation] ([RoleID], [PrivilegeCode], [LastUpdateUserUID], [LastUpdateUserName], [LastUpdateTime]) VALUES (3, N'10040', N'admin', N'����Ա', CAST(0x00009F0E00CBA7E6 AS DateTime))
INSERT [dbo].[RolePrivilegeRelation] ([RoleID], [PrivilegeCode], [LastUpdateUserUID], [LastUpdateUserName], [LastUpdateTime]) VALUES (3, N'10050', N'admin', N'����Ա', CAST(0x00009F0E00CBA7E6 AS DateTime))
INSERT [dbo].[RolePrivilegeRelation] ([RoleID], [PrivilegeCode], [LastUpdateUserUID], [LastUpdateUserName], [LastUpdateTime]) VALUES (3, N'10060', N'admin', N'����Ա', CAST(0x00009F0E00CBA7E6 AS DateTime))
INSERT [dbo].[RolePrivilegeRelation] ([RoleID], [PrivilegeCode], [LastUpdateUserUID], [LastUpdateUserName], [LastUpdateTime]) VALUES (3, N'10070', N'admin', N'����Ա', CAST(0x00009F0E00CBA7E6 AS DateTime))
/****** Object:  StoredProcedure [dbo].[SP_SaveRoleInfo]    Script Date: 06/27/2011 21:37:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=====================================
-- ����¼���浽 RoleInfos ��
--=====================================
CREATE PROCEDURE [dbo].[SP_SaveRoleInfo]
	 @RoleID  INT
	,@RoleCode  VARCHAR(50)
	,@RoleName  NVARCHAR(200)
	,@Remark  NVARCHAR(2000)
	,@ParentID  INT
	,@IsSystem  bit	
	,@LastUpdateUserUID  VARCHAR(50)
	,@LastUpdateUserName  NVARCHAR(200)	
AS
BEGIN	
	DECLARE @RolePath VARCHAR(4000)
	
	DECLARE @ParentPath varchar(4000)
	IF @ParentID>0
	BEGIN
		if  NOT EXISTS (SELECT 1 FROM [RoleInfos] WHERE RoleID=@ParentID)
		BEGIN
			 RAISERROR ('��ѡ��ĸ���ɫ�����ڣ������Ѿ���ɾ��', 16, 1)
			 RETURN
		END
		 SELECT @ParentPath=ISNULL([RolePath],'') FROM [RoleInfos] WHERE RoleID=@ParentID
		 SELECT @RolePath = CASE WHEN @ParentPath='' THEN '.'+CONVERT(varchar(16),@ParentID)+'.' ELSE @ParentPath+CONVERT(varchar(16),@ParentID)+'.' END 
    END
    ELSE
    BEGIN		
		SET @RolePath = ''	
		SET @ParentID=null	 
    END
    
    
	IF  EXISTS (SELECT 1 FROM [RoleInfos] WHERE [RoleID]=@RoleID)
	BEGIN --�޸�
		UPDATE [RoleInfos] SET [RoleCode]=@RoleCode,[RoleName]=@RoleName,[Remark]=@Remark,[ParentID]=@ParentID,[IsSystem]=@IsSystem,[RolePath]=@RolePath,[LastUpdateUserUID]=@LastUpdateUserUID,[LastUpdateUserName]=@LastUpdateUserName,[LastUpdateTime]=GETDATE()		
		WHERE [RoleID]=@RoleID 		
	END
	ELSE
	BEGIN  --����
		INSERT INTO [RoleInfos] 
			   ([RoleCode],[RoleName],[Remark],[ParentID],[IsSystem],[RolePath],[LastUpdateUserUID],[LastUpdateUserName],[LastUpdateTime])
		VALUES (@RoleCode,@RoleName,@Remark,@ParentID,@IsSystem,@RolePath,@LastUpdateUserUID,@LastUpdateUserName,GETDATE())
	END
END
GO
/****** Object:  StoredProcedure [dbo].[SP_SavePrivilege]    Script Date: 06/27/2011 21:37:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=====================================
-- ����¼���浽 Privileges ��
--=====================================
CREATE PROCEDURE [dbo].[SP_SavePrivilege]
	@PrivilegeCode  VARCHAR(20)
	,@PrivilegeName  NVARCHAR(200)
	,@PrivilegeType  TINYINT
	,@Remark  NVARCHAR(2000)
	,@ParentID  VARCHAR(20)
	,@Uri  VARCHAR(2000)
	,@Sequence  INT
	,@LastUpdateUserUID  VARCHAR(50)
	,@LastUpdateUserName  NVARCHAR(200)
AS
BEGIN	
	IF  NOT EXISTS (SELECT 1 FROM [Privileges] WHERE [PrivilegeCode]=@PrivilegeCode)
	BEGIN --�޸�
		UPDATE [Privileges] SET [PrivilegeName]=@PrivilegeName,[PrivilegeType]=@PrivilegeType,[Remark]=@Remark,[ParentID]=@ParentID,[Uri]=@Uri,[Sequence]=@Sequence,[LastUpdateUserUID]=@LastUpdateUserUID,[LastUpdateUserName]=@LastUpdateUserName,[LastUpdateTime]=GETDATE()	
		WHERE [PrivilegeCode]=@PrivilegeCode 		
	END
	ELSE
	BEGIN  --����
		INSERT INTO [Privileges] 
			   ([PrivilegeCode],[PrivilegeName],[PrivilegeType],[Remark],[ParentID],[Uri],[Sequence],[LastUpdateUserUID],[LastUpdateUserName],[LastUpdateTime])
		VALUES (@PrivilegeCode,@PrivilegeName,@PrivilegeType,@Remark,@ParentID,@Uri,@Sequence,@LastUpdateUserUID,@LastUpdateUserName,GETDATE())
	END
END
GO
/****** Object:  StoredProcedure [dbo].[SP_SaveOrgInfo]    Script Date: 06/27/2011 21:37:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<xuanye>
-- Create date: <2011-05-29>
-- Description:	<���沿����Ϣ>
-- =============================================
CREATE PROCEDURE [dbo].[SP_SaveOrgInfo]
	@OrgCode varchar(50), --��֯����
	@OrgName nvarchar(200),  --��֯����
    @ParentCode varchar(50),  --��Code
    @Remark nvarchar(2000),  -- ��ע
    @OrgType tinyint,  --��֯����
    @Sequence int,  --����
    @LastUpdateUserUID varchar(50),
    @LastUpdateUserName nvarchar(100)    
AS
BEGIN

    DECLARE @Path varchar(1000)
	DECLARE @ParentPath varchar(1000)
	DECLARE @UnitCode varchar(50)
	DECLARE @UnitName nvarchar(200)
	IF @ParentCode<>'-1'  
	BEGIN
		if  NOT EXISTS (SELECT 1 FROM Organizations WHERE OrgCode=@ParentCode)
		BEGIN
			 RAISERROR ('��ѡ��ĸ���֯�����ڣ������Ѿ���ɾ��', 16, 1)
			 RETURN
		END
    END
    IF(@OrgType=0)
    BEGIN
		SET @UnitCode =@OrgCode
		SET @UnitName = @OrgName
    END
    ELSE
    BEGIN
		SELECT @UnitCode = UnitCode,@UnitName=UnitName From Organizations WHERE OrgCode=@ParentCode
    END
    SELECT @ParentPath=[Path] FROM Organizations WHERE OrgCode=@ParentCode
    SELECT @Path = CASE WHEN ISNULL(@ParentPath,'')='' THEN '.'+@ParentCode+'.' ELSE @ParentPath+@ParentCode+'.' END 
    IF EXISTS (SELECT 1 FROM Organizations WHERE OrgCode=@OrgCode)
    BEGIN
		UPDATE Organizations SET [OrgName]=@OrgName,[ParentCode]=@ParentCode
		,[Path]=@Path,[Remark]=@Remark,[Sequence]=@Sequence,[LastUpdateUserUID]=@LastUpdateUserUID
		,[LastUpdateUserName]=@LastUpdateUserName,[LastUpdateTime]=GETDATE(),OrgType=@OrgType,UnitCode=@UnitCode,UnitName=@UnitName
		WHERE OrgCode=@OrgCode
    END
    ELSE
    BEGIN
		INSERT INTO Organizations ([OrgCode],[OrgName],[ParentCode],[Path],[Remark],[Sequence],[LastUpdateUserUID],[LastUpdateUserName],[LastUpdateTime],OrgType,UnitCode,UnitName)
		VALUES (@OrgCode,@OrgName,@ParentCode,@Path,@Remark,@Sequence,@LastUpdateUserUID,@LastUpdateUserName,GETDATE(),@OrgType,@UnitCode,@UnitName)
    END    
   
END
GO
/****** Object:  StoredProcedure [dbo].[SP_SetRoleRolePrivilege]    Script Date: 06/27/2011 21:37:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<xuanye>
-- Create date: <2011-06-17>
-- Description:	<���ý�ɫ��Ȩ��>
-- =============================================
CREATE PROCEDURE [dbo].[SP_SetRoleRolePrivilege]
	@RoleID int,
	@AddIDs Varchar(4000),
	@MinusIDs varchar(4000),
	@UserID varchar(50),
	@UserName nvarchar(100)
	
AS
BEGIN
	IF NOT EXISTS (SELECT 1 FROM RoleInfos WHERE RoleID=@RoleID)
	BEGIN
		RAISERROR('��ɫ������',16,1)
		RETURN
	END
	ELSE
	BEGIN
	
		IF(ISNULL(@AddIDS,'') <>'')
		BEGIN
			--������Ȩ
			INSERT INTO RolePrivilegeRelation (RoleID,PrivilegeCode,LastUpdateUserUID,LastUpdateUserName,LastUpdateTime)
			SELECT @RoleID,A.PrivilegeCode,@UserID,@UserName,GETDATE() FROM Privileges A  --����Ȩ��ID����Ч��
			INNER JOIN ( SELECT item FROM dbo.fn_split(@AddIDS,',')) B ON A.PrivilegeCode=B.item
			LEFT JOIN RolePrivilegeRelation C ON A.PrivilegeCode=C.PrivilegeCode and C.RoleID=@RoleID  --�����Ѿ����ڵ�
			WHERE C.RoleID IS NULL  --�����Ѿ����ڵ� 
		END
		
		IF(ISNULL(@MinusIDS,'') <>'')
		BEGIN
			--ɾ����Ȩ
			DELETE A FROM RolePrivilegeRelation A
			INNER JOIN ( SELECT item FROM dbo.fn_split(@MinusIDS,',')) B ON A.PrivilegeCode=B.Item
			WHERE A.RoleID = @RoleID
		END
	
	END

END
GO
/****** Object:  StoredProcedure [dbo].[SP_RoleCheckUserRight]    Script Date: 06/27/2011 21:37:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<xuanye>
-- Create date: <2011-06-17>
-- Description:	<�ж��û��Ƿ��ܶ�ĳ��ɫ��Ȩ>
-- =============================================
CREATE PROCEDURE [dbo].[SP_RoleCheckUserRight]

@RoleID int,
@UserID varchar(50)

AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Path VARCHAR(4000)
	if not exists (select 1 from RoleInfos where RoleID = @RoleID)
	begin
		select 0
	end
	else
	begin
		  select @Path = isnull([RolePath],'')+Convert(varchar(16),RoleID) from RoleInfos where RoleID = @RoleID 
		  if EXISTS (SElECT  1  from RoleUserRelation A 
									 inner join RoleInfos B on A.RoleID=B.RoleID  
									 where A.UserUID=@UserID 
									 and ( B.RoleID=@RoleID or Charindex(B.[RolePath]+Convert(varchar(12),B.RoleID),@Path)>0))
		  begin
			 select 1
		  end
		  else
		  begin
			 select 0
		  end
	end
END
GO
/****** Object:  StoredProcedure [dbo].[SP_RemoveRoleUsers]    Script Date: 06/27/2011 21:37:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_RemoveRoleUsers]
	@RoleID int,
	@UserIDs varchar(8000)
AS
BEGIN
	IF NOT EXISTS (SELECT 1 FROM RoleInfos WHERE RoleID =@RoleID )
	BEGIN
		Raiserror('ָ���Ľ�ɫ�����ڻ����Ѿ���ɾ��',16,1)
		Return
	END
	ELSE
	BEGIN
		IF (ISNULL(@UserIDs,'') <> '' )
		begin		
			DELETE A FROM RoleUserRelation A
			INNER JOIN (SELECT item FROM dbo.fn_split(@UserIDs,',')) B ON A.UserUID = B.item
			WHERE A.RoleID =@RoleID	
		end
	END
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteUserInfo]    Script Date: 06/27/2011 21:37:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<xuanye>
-- Create date: <2011-06-01>
-- Description:	<ɾ���û���Ϣ>
-- =============================================
CREATE PROCEDURE [dbo].[SP_DeleteUserInfo]
	@UserUID varchar(50)
AS
BEGIN
	DELETE FROM RoleUserRelation WHERE UserUID=@UserUID
	DELETE FROM UserInfos WHERE UserUID=@UserUID
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DeletePrivilege]    Script Date: 06/27/2011 21:37:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<xuanye>
-- Create date: <2011-06-04>
-- Description:	<ɾ��Ȩ��>
-- =============================================
CREATE PROCEDURE [dbo].[SP_DeletePrivilege]
	@PrivilegeCode Varchar(20)
AS
BEGIN
	IF  not Exists (Select 1 From Privileges where PrivilegeCode=@PrivilegeCode)
	BEGIN
		 RAISERROR ('Ȩ�޲����ڻ����Ѿ���ɾ��', 16, 1)
		 RETURN
	END
	ELSE IF EXISTS (SELECT 1 FROM Privileges WHERE ParentID=@PrivilegeCode)
	BEGIN
		 RAISERROR ('������Ȩ�޲��ܱ�ɾ��', 16, 1)
		 RETURN
	END
	ELSE
	BEGIN
		Delete From RolePrivilegeRelation where PrivilegeCode=@PrivilegeCode
		Delete From Privileges where PrivilegeCode=@PrivilegeCode
	END
END
GO
/****** Object:  StoredProcedure [dbo].[SP_AddRoleUsers]    Script Date: 06/27/2011 21:37:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		xuanye
-- Create date: 2011-06-12
-- Description:	���ɫ�������û�
-- =============================================
CREATE PROCEDURE [dbo].[SP_AddRoleUsers] 
	@RoleID int,
	@UserIDs varchar(8000),
	@OpUserID Varchar(50),
	@OpUserName NVarchar(100)
AS
BEGIN
	IF NOT EXISTS (SELECT 1 FROM RoleInfos WHERE RoleID =@RoleID )
	BEGIN
		Raiserror('ָ���Ľ�ɫ�����ڻ����Ѿ���ɾ��',16,1)
		Return
	END
	ELSE
	BEGIN
		IF (ISNULL(@UserIDs,'') <> '' )
		begin		
			
			INSERT INTO RoleUserRelation (RoleID,UserUID,LastUpdateUserUID,LastUpdateUserName,LastUpdateTime)
			SELECT @RoleID,a.UserUID,@OpUserID,@OpUserName,GETDATE() FROM UserInfos A 
			INNER JOIN (SELECT item FROM dbo.fn_split(@UserIDs,',')) B ON A.UserUID =B.item 
			LEFT JOIN RoleUserRelation C  ON A.UserUID = C.UserUID and C.RoleID=@RoleID
			WHERE C.RoleID IS NULL --�����ظ��Ĳ���
		end
	END
END
GO
/****** Object:  Default [DF__DictInfos__IsSys__540C7B00]    Script Date: 06/27/2011 21:37:39 ******/
ALTER TABLE [dbo].[DictInfos] ADD  DEFAULT ((0)) FOR [IsSystem]
GO
/****** Object:  Default [DF__Organizat__LastU__45BE5BA9]    Script Date: 06/27/2011 21:37:39 ******/
ALTER TABLE [dbo].[Organizations] ADD  CONSTRAINT [DF__Organizat__LastU__45BE5BA9]  DEFAULT (getdate()) FOR [LastUpdateTime]
GO
/****** Object:  Default [DF__Privilege__LastU__21B6055D]    Script Date: 06/27/2011 21:37:39 ******/
ALTER TABLE [dbo].[Privileges] ADD  CONSTRAINT [DF__Privilege__LastU__21B6055D]  DEFAULT (getdate()) FOR [LastUpdateTime]
GO
/****** Object:  Default [DF__RoleInfos__IsSys__3C34F16F]    Script Date: 06/27/2011 21:37:39 ******/
ALTER TABLE [dbo].[RoleInfos] ADD  DEFAULT ((0)) FOR [IsSystem]
GO
/****** Object:  Default [DF__RoleInfos__LastU__3D2915A8]    Script Date: 06/27/2011 21:37:39 ******/
ALTER TABLE [dbo].[RoleInfos] ADD  DEFAULT (getdate()) FOR [LastUpdateTime]
GO
/****** Object:  Default [DF__RolePrivi__LastU__489AC854]    Script Date: 06/27/2011 21:37:39 ******/
ALTER TABLE [dbo].[RolePrivilegeRelation] ADD  DEFAULT (getdate()) FOR [LastUpdateTime]
GO
/****** Object:  Default [DF__RoleUserR__LastU__37703C52]    Script Date: 06/27/2011 21:37:39 ******/
ALTER TABLE [dbo].[RoleUserRelation] ADD  DEFAULT (getdate()) FOR [LastUpdateTime]
GO
/****** Object:  Default [DF__UserInfos__IsMan__628FA481]    Script Date: 06/27/2011 21:37:39 ******/
ALTER TABLE [dbo].[UserInfos] ADD  CONSTRAINT [DF__UserInfos__IsMan__628FA481]  DEFAULT ((0)) FOR [IsManager]
GO
/****** Object:  Default [DF__UserInfos__Accou__6383C8BA]    Script Date: 06/27/2011 21:37:39 ******/
ALTER TABLE [dbo].[UserInfos] ADD  CONSTRAINT [DF__UserInfos__Accou__6383C8BA]  DEFAULT ((0)) FOR [AccountState]
GO
/****** Object:  Default [DF__UserInfos__LastU__656C112C]    Script Date: 06/27/2011 21:37:39 ******/
ALTER TABLE [dbo].[UserInfos] ADD  CONSTRAINT [DF__UserInfos__LastU__656C112C]  DEFAULT (getdate()) FOR [LastUpdateTime]
GO
/****** Object:  Check [CKC_LOGTYPE_LOGS]    Script Date: 06/27/2011 21:37:39 ******/
ALTER TABLE [dbo].[Logs]  WITH CHECK ADD  CONSTRAINT [CKC_LOGTYPE_LOGS] CHECK  (([LogType]=(9) OR [LogType]=(2) OR [LogType]=(1) OR [LogType]=(0)))
GO
ALTER TABLE [dbo].[Logs] CHECK CONSTRAINT [CKC_LOGTYPE_LOGS]
GO
/****** Object:  Check [CKC_ORGTYPE_ORGANIZA]    Script Date: 06/27/2011 21:37:39 ******/
ALTER TABLE [dbo].[Organizations]  WITH CHECK ADD  CONSTRAINT [CKC_ORGTYPE_ORGANIZA] CHECK  (([OrgType] IS NULL OR ([OrgType]=(2) OR [OrgType]=(1) OR [OrgType]=(0))))
GO
ALTER TABLE [dbo].[Organizations] CHECK CONSTRAINT [CKC_ORGTYPE_ORGANIZA]
GO
/****** Object:  Check [CKC_PRIVILEGETYPE_PRIVILEG]    Script Date: 06/27/2011 21:37:39 ******/
ALTER TABLE [dbo].[Privileges]  WITH CHECK ADD  CONSTRAINT [CKC_PRIVILEGETYPE_PRIVILEG] CHECK  (([PrivilegeType]=(2) OR [PrivilegeType]=(1)))
GO
ALTER TABLE [dbo].[Privileges] CHECK CONSTRAINT [CKC_PRIVILEGETYPE_PRIVILEG]
GO
/****** Object:  Check [CKC_ACCOUNTSTATE_USERINFO]    Script Date: 06/27/2011 21:37:39 ******/
ALTER TABLE [dbo].[UserInfos]  WITH CHECK ADD  CONSTRAINT [CKC_ACCOUNTSTATE_USERINFO] CHECK  (([AccountState]=(1) OR [AccountState]=(0)))
GO
ALTER TABLE [dbo].[UserInfos] CHECK CONSTRAINT [CKC_ACCOUNTSTATE_USERINFO]
GO
/****** Object:  ForeignKey [FK_ROLEPRIV_REFERENCE_PRIVILEG]    Script Date: 06/27/2011 21:37:39 ******/
ALTER TABLE [dbo].[RolePrivilegeRelation]  WITH CHECK ADD  CONSTRAINT [FK_ROLEPRIV_REFERENCE_PRIVILEG] FOREIGN KEY([PrivilegeCode])
REFERENCES [dbo].[Privileges] ([PrivilegeCode])
GO
ALTER TABLE [dbo].[RolePrivilegeRelation] CHECK CONSTRAINT [FK_ROLEPRIV_REFERENCE_PRIVILEG]
GO
/****** Object:  ForeignKey [FK_ROLEPRIV_REFERENCE_ROLEINFO]    Script Date: 06/27/2011 21:37:39 ******/
ALTER TABLE [dbo].[RolePrivilegeRelation]  WITH CHECK ADD  CONSTRAINT [FK_ROLEPRIV_REFERENCE_ROLEINFO] FOREIGN KEY([RoleID])
REFERENCES [dbo].[RoleInfos] ([RoleID])
GO
ALTER TABLE [dbo].[RolePrivilegeRelation] CHECK CONSTRAINT [FK_ROLEPRIV_REFERENCE_ROLEINFO]
GO
/****** Object:  ForeignKey [FK_ROLEUSER_REFERENCE_USERINFO]    Script Date: 06/27/2011 21:37:39 ******/
ALTER TABLE [dbo].[RoleUserRelation]  WITH CHECK ADD  CONSTRAINT [FK_ROLEUSER_REFERENCE_USERINFO] FOREIGN KEY([UserUID])
REFERENCES [dbo].[UserInfos] ([UserUID])
GO
ALTER TABLE [dbo].[RoleUserRelation] CHECK CONSTRAINT [FK_ROLEUSER_REFERENCE_USERINFO]
GO
