CREATE DATABASE Demo_Larin
GO
USE [Demo_Larin]
GO
/****** Object:  Table [dbo].[Material_type_import]    Script Date: 06.05.2025 13:34:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Material_type_import](
	[Тип_материала] [nvarchar](50) NOT NULL,
	[Процент_брака_материала] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Material_type_import] PRIMARY KEY CLUSTERED 
(
	[Тип_материала] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Partner_products_import]    Script Date: 06.05.2025 13:34:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Partner_products_import](
	[Продукция] [nvarchar](100) NOT NULL,
	[Наименование_партнера] [nvarchar](50) NOT NULL,
	[Количество_продукции] [int] NOT NULL,
	[Дата_продажи] [datetime2](7) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Partners_import]    Script Date: 06.05.2025 13:34:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Partners_import](
	[Тип_партнера] [nvarchar](50) NOT NULL,
	[Наименование_партнера] [nvarchar](50) NOT NULL,
	[Директор] [nvarchar](50) NOT NULL,
	[Электронная_почта_партнера] [nvarchar](50) NOT NULL,
	[Телефон_партнера] [float] NOT NULL,
	[Юридический_адрес_партнера] [nvarchar](100) NOT NULL,
	[ИНН] [float] NOT NULL,
	[Рейтинг] [int] NOT NULL,
 CONSTRAINT [PK_Partners_import] PRIMARY KEY CLUSTERED 
(
	[Наименование_партнера] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_type_import]    Script Date: 06.05.2025 13:34:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_type_import](
	[Тип_продукции] [nvarchar](50) NOT NULL,
	[Коэффициент_типа_продукции] [float] NOT NULL,
 CONSTRAINT [PK_Product_type_import] PRIMARY KEY CLUSTERED 
(
	[Тип_продукции] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products_import]    Script Date: 06.05.2025 13:34:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products_import](
	[Тип_продукции] [nvarchar](50) NOT NULL,
	[Наименование_продукции] [nvarchar](100) NOT NULL,
	[Артикул] [int] NOT NULL,
	[Минимальная_стоимость_для_партнера] [float] NOT NULL,
	[Тип_материала] [nvarchar](50) NULL,
 CONSTRAINT [PK_Products_import] PRIMARY KEY CLUSTERED 
(
	[Наименование_продукции] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Material_type_import] ([Тип_материала], [Процент_брака_материала]) VALUES (N'Тип материала 1', N'0,10%')
INSERT [dbo].[Material_type_import] ([Тип_материала], [Процент_брака_материала]) VALUES (N'Тип материала 2', N'0,95%')
INSERT [dbo].[Material_type_import] ([Тип_материала], [Процент_брака_материала]) VALUES (N'Тип материала 3', N'0,28%')
INSERT [dbo].[Material_type_import] ([Тип_материала], [Процент_брака_материала]) VALUES (N'Тип материала 4', N'0,55%')
INSERT [dbo].[Material_type_import] ([Тип_материала], [Процент_брака_материала]) VALUES (N'Тип материала 5', N'0,34%')
GO
INSERT [dbo].[Partner_products_import] ([Продукция], [Наименование_партнера], [Количество_продукции], [Дата_продажи]) VALUES (N'Паркетная доска Ясень темный однополосная 14 мм', N'База Строитель', 15500, CAST(N'2023-03-23T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Partner_products_import] ([Продукция], [Наименование_партнера], [Количество_продукции], [Дата_продажи]) VALUES (N'Ламинат Дуб дымчато-белый 33 класс 12 мм', N'База Строитель', 12350, CAST(N'2023-12-18T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Partner_products_import] ([Продукция], [Наименование_партнера], [Количество_продукции], [Дата_продажи]) VALUES (N'Ламинат Дуб серый 32 класс 8 мм с фаской', N'База Строитель', 37400, CAST(N'2024-06-07T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Partner_products_import] ([Продукция], [Наименование_партнера], [Количество_продукции], [Дата_продажи]) VALUES (N'Инженерная доска Дуб Французская елка однополосная 12 мм', N'Паркет 29', 35000, CAST(N'2022-12-02T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Partner_products_import] ([Продукция], [Наименование_партнера], [Количество_продукции], [Дата_продажи]) VALUES (N'Пробковое напольное клеевое покрытие 32 класс 4 мм', N'Паркет 29', 1250, CAST(N'2023-05-17T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Partner_products_import] ([Продукция], [Наименование_партнера], [Количество_продукции], [Дата_продажи]) VALUES (N'Ламинат Дуб дымчато-белый 33 класс 12 мм', N'Паркет 29', 1000, CAST(N'2024-06-07T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Partner_products_import] ([Продукция], [Наименование_партнера], [Количество_продукции], [Дата_продажи]) VALUES (N'Паркетная доска Ясень темный однополосная 14 мм', N'Паркет 29', 7550, CAST(N'2024-07-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Partner_products_import] ([Продукция], [Наименование_партнера], [Количество_продукции], [Дата_продажи]) VALUES (N'Паркетная доска Ясень темный однополосная 14 мм', N'Стройсервис', 7250, CAST(N'2023-01-22T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Partner_products_import] ([Продукция], [Наименование_партнера], [Количество_продукции], [Дата_продажи]) VALUES (N'Инженерная доска Дуб Французская елка однополосная 12 мм', N'Стройсервис', 2500, CAST(N'2024-07-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Partner_products_import] ([Продукция], [Наименование_партнера], [Количество_продукции], [Дата_продажи]) VALUES (N'Ламинат Дуб серый 32 класс 8 мм с фаской', N'Ремонт и отделка', 59050, CAST(N'2023-03-20T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Partner_products_import] ([Продукция], [Наименование_партнера], [Количество_продукции], [Дата_продажи]) VALUES (N'Ламинат Дуб дымчато-белый 33 класс 12 мм', N'Ремонт и отделка', 37200, CAST(N'2024-03-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Partner_products_import] ([Продукция], [Наименование_партнера], [Количество_продукции], [Дата_продажи]) VALUES (N'Пробковое напольное клеевое покрытие 32 класс 4 мм', N'Ремонт и отделка', 4500, CAST(N'2024-05-14T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Partner_products_import] ([Продукция], [Наименование_партнера], [Количество_продукции], [Дата_продажи]) VALUES (N'Ламинат Дуб дымчато-белый 33 класс 12 мм', N'МонтажПро', 50000, CAST(N'2023-09-19T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Partner_products_import] ([Продукция], [Наименование_партнера], [Количество_продукции], [Дата_продажи]) VALUES (N'Ламинат Дуб серый 32 класс 8 мм с фаской', N'МонтажПро', 670000, CAST(N'2023-11-10T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Partner_products_import] ([Продукция], [Наименование_партнера], [Количество_продукции], [Дата_продажи]) VALUES (N'Паркетная доска Ясень темный однополосная 14 мм', N'МонтажПро', 35000, CAST(N'2024-04-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Partner_products_import] ([Продукция], [Наименование_партнера], [Количество_продукции], [Дата_продажи]) VALUES (N'Инженерная доска Дуб Французская елка однополосная 12 мм', N'МонтажПро', 25000, CAST(N'2024-06-12T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Partners_import] ([Тип_партнера], [Наименование_партнера], [Директор], [Электронная_почта_партнера], [Телефон_партнера], [Юридический_адрес_партнера], [ИНН], [Рейтинг]) VALUES (N'ЗАО', N'База Строитель', N'Иванова Александра Ивановна', N'aleksandraivanova@ml.ru', 4931234567, N'652050, Кемеровская область, город Юрга, ул. Лесная, 15', 2222455179, 7)
INSERT [dbo].[Partners_import] ([Тип_партнера], [Наименование_партнера], [Директор], [Электронная_почта_партнера], [Телефон_партнера], [Юридический_адрес_партнера], [ИНН], [Рейтинг]) VALUES (N'ООО', N'Живое слово', N'Иванов И.И.', N'Ivanov@gmail.com', 89022737362, N'ул. Первомайская, 72', 4827374723, 3)
INSERT [dbo].[Partners_import] ([Тип_партнера], [Наименование_партнера], [Директор], [Электронная_почта_партнера], [Телефон_партнера], [Юридический_адрес_партнера], [ИНН], [Рейтинг]) VALUES (N'ЗАО', N'Канцелярия', N'Петров Виктор Иванович', N'petrov@gmail.com', 78673214234, N'ул. Восточная, 57', 6575677655, 5)
INSERT [dbo].[Partners_import] ([Тип_партнера], [Наименование_партнера], [Директор], [Электронная_почта_партнера], [Телефон_партнера], [Юридический_адрес_партнера], [ИНН], [Рейтинг]) VALUES (N'ЗАО', N'МонтажПро', N'Степанов Степан Сергеевич', N'stepanov@stepan.ru', 9128883333, N'309500, Белгородская область, город Старый Оскол, ул. Рабочая, 122', 5552431140, 10)
INSERT [dbo].[Partners_import] ([Тип_партнера], [Наименование_партнера], [Директор], [Электронная_почта_партнера], [Телефон_партнера], [Юридический_адрес_партнера], [ИНН], [Рейтинг]) VALUES (N'ООО', N'Паркет 29', N'Петров Василий Петрович', N'vppetrov@vl.ru', 9871235678, N'164500, Архангельская область, город Северодвинск, ул. Строителей, 18', 3333888520, 7)
INSERT [dbo].[Partners_import] ([Тип_партнера], [Наименование_партнера], [Директор], [Электронная_почта_партнера], [Телефон_партнера], [Юридический_адрес_партнера], [ИНН], [Рейтинг]) VALUES (N'ОАО', N'Ремонт и отделка', N'Воробьева Екатерина Валерьевна', N'ekaterina.vorobeva@ml.ru', 4442223311, N'143960, Московская область, город Реутов, ул. Свободы, 51', 1111520857, 5)
INSERT [dbo].[Partners_import] ([Тип_партнера], [Наименование_партнера], [Директор], [Электронная_почта_партнера], [Телефон_партнера], [Юридический_адрес_партнера], [ИНН], [Рейтинг]) VALUES (N'ПАО', N'Стройсервис', N'Соловьев Андрей Николаевич', N'ansolovev@st.ru', 8122233200, N'188910, Ленинградская область, город Приморск, ул. Парковая, 21', 4440391035, 7)
GO
INSERT [dbo].[Product_type_import] ([Тип_продукции], [Коэффициент_типа_продукции]) VALUES (N'Ламинат', 2.35)
INSERT [dbo].[Product_type_import] ([Тип_продукции], [Коэффициент_типа_продукции]) VALUES (N'Массивная доска', 5.15)
INSERT [dbo].[Product_type_import] ([Тип_продукции], [Коэффициент_типа_продукции]) VALUES (N'Паркетная доска', 4.34)
INSERT [dbo].[Product_type_import] ([Тип_продукции], [Коэффициент_типа_продукции]) VALUES (N'Пробковое покрытие', 1.5)
GO
INSERT [dbo].[Products_import] ([Тип_продукции], [Наименование_продукции], [Артикул], [Минимальная_стоимость_для_партнера], [Тип_материала]) VALUES (N'Паркетная доска', N'Инженерная доска Дуб Французская елка однополосная 12 мм', 8858958, 7330.99, NULL)
INSERT [dbo].[Products_import] ([Тип_продукции], [Наименование_продукции], [Артикул], [Минимальная_стоимость_для_партнера], [Тип_материала]) VALUES (N'Ламинат', N'Ламинат Дуб дымчато-белый 33 класс 12 мм', 7750282, 1799.33, NULL)
INSERT [dbo].[Products_import] ([Тип_продукции], [Наименование_продукции], [Артикул], [Минимальная_стоимость_для_партнера], [Тип_материала]) VALUES (N'Ламинат', N'Ламинат Дуб серый 32 класс 8 мм с фаской', 7028748, 3890.41, NULL)
INSERT [dbo].[Products_import] ([Тип_продукции], [Наименование_продукции], [Артикул], [Минимальная_стоимость_для_партнера], [Тип_материала]) VALUES (N'Паркетная доска', N'Паркетная доска Ясень темный однополосная 14 мм', 8758385, 4456.9, NULL)
INSERT [dbo].[Products_import] ([Тип_продукции], [Наименование_продукции], [Артикул], [Минимальная_стоимость_для_партнера], [Тип_материала]) VALUES (N'Пробковое покрытие', N'Пробковое напольное клеевое покрытие 32 класс 4 мм', 5012543, 5450.59, NULL)
GO
ALTER TABLE [dbo].[Partner_products_import]  WITH CHECK ADD  CONSTRAINT [FK_Partner_products_import_Partners_import] FOREIGN KEY([Наименование_партнера])
REFERENCES [dbo].[Partners_import] ([Наименование_партнера])
GO
ALTER TABLE [dbo].[Partner_products_import] CHECK CONSTRAINT [FK_Partner_products_import_Partners_import]
GO
ALTER TABLE [dbo].[Partner_products_import]  WITH CHECK ADD  CONSTRAINT [FK_Partner_products_import_Products_import] FOREIGN KEY([Продукция])
REFERENCES [dbo].[Products_import] ([Наименование_продукции])
GO
ALTER TABLE [dbo].[Partner_products_import] CHECK CONSTRAINT [FK_Partner_products_import_Products_import]
GO
ALTER TABLE [dbo].[Products_import]  WITH CHECK ADD  CONSTRAINT [FK_Products_import_Material_type_import] FOREIGN KEY([Тип_материала])
REFERENCES [dbo].[Material_type_import] ([Тип_материала])
GO
ALTER TABLE [dbo].[Products_import] CHECK CONSTRAINT [FK_Products_import_Material_type_import]
GO
ALTER TABLE [dbo].[Products_import]  WITH CHECK ADD  CONSTRAINT [FK_Products_import_Product_type_import] FOREIGN KEY([Тип_продукции])
REFERENCES [dbo].[Product_type_import] ([Тип_продукции])
GO
ALTER TABLE [dbo].[Products_import] CHECK CONSTRAINT [FK_Products_import_Product_type_import]
GO
