# Лабораторная Работа №2 - Угрозы Безопасности Информации
Данное приложение скачивает xlsx файл с сайта ФСТЭК и парсит его, используя библиотеку [LinqToExcel](https://github.com/paulyoder/LinqToExcel), в DataGrid, который разбит на страницы. Мы можем просмотривать УБИ в сокращенном режиме, а также обновлять локальную базу с полным отчетом произошедших изменений. Имеется возможность сохранения таблицы в виде txt файла. 

## Описание
### Threat.cs
* Представление УБИ как 8 строковых свойств (по сути строка таблицы excel)
### Data.cs
* Позволяет нам создавать объекты со свойством, которое представляется в виде списка угроз (его мы и отображаем в DataGrid), а также содержит в себе методы, отвечающие за представление листа угроз как стринг, сжатие информации и ее сравнение. Именно здесь находится конструктор, внутри которого происходит парсинг эксель файла
### MainWindow.xaml(.cs)
* Здесь располагается весь UI 
### FileManagment.cs)
* Статический вспомогательный класс, его методы отвечают за загрузку файла из интернета и сохранение информации на жд
### PagingCollectionView.cs
* Класс для поддержки пагинации
### UpdateSuccess.xaml(.cs)
* Окно, которое открывается при успешном обновлении локальной базы данных, содержит в себе отчет об изменениях в УБИ
### Change.cs
* Небольшой класс для удобства при работе с отчетом по изменениям в локальной базе данных 
