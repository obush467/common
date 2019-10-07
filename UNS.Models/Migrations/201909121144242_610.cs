namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _610 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.integraDU", name: "БТИ - Тип стен", newName: "BTIWallType");
            RenameColumn(table: "dbo.integraDU", name: "БТИ - Назначение", newName: "BTITarget");
            RenameColumn(table: "dbo.integraDU", name: "Тип стен", newName: "WallType");
            RenameColumn(table: "dbo.integraDU", name: "Тип съёмки", newName: "Foto");
            RenameColumn(table: "dbo.integraDU", name: "Контактные данные", newName: "Contacts");
            RenameColumn(table: "dbo.integraDU", name: "Руководитель ФИО", newName: "Director");
            RenameColumn(table: "dbo.integraDU", name: "Должность руководителя", newName: "DirectorPosition");
            RenameColumn(table: "dbo.integraDU", name: "номер исх письма", newName: "LetterOutNumber");
            RenameColumn(table: "dbo.integraDU", name: "Дата исх письма", newName: "LetterOutData");
            RenameColumn(table: "dbo.integraDU", name: "Наличие ответа вход", newName: "LetterIn");
            RenameColumn(table: "dbo.integraDU", name: "Дата согласования", newName: "CoordinationDate");
            RenameColumn(table: "dbo.integraDU", name: "Дата передачи в производство", newName: "IntoProductionDate");
            RenameColumn(table: "dbo.integraDU", name: "ХОТЕЛКИ на МОНТАЖА", newName: "Istallation_Requirements");
            RenameColumn(table: "dbo.integraDU", name: "Готово к монтажу", newName: "Done_to_installation");
            //AlterColumn("dbo.integraDU", "Done_to_installation", c => c.DateTime(nullable: true));
            DropColumn("dbo.integraDU", "Дата выд в монтаж");
            DropColumn("dbo.integraDU", "Дата монтажа");
            DropColumn("dbo.integraDU", "Дата подключения");
        }

        public override void Down()
        {
            AddColumn("dbo.integraDU", "Дата подключения", c => c.String(maxLength: 255));
            AddColumn("dbo.integraDU", "Дата монтажа", c => c.String(maxLength: 255));
            AddColumn("dbo.integraDU", "Дата выд в монтаж", c => c.String(maxLength: 255));
            AlterColumn("dbo.integraDU", "Done_to_installation", c => c.String(maxLength: 255));
            RenameColumn(table: "dbo.integraDU", name: "Done_to_installation", newName: "Готово к монтажу");
            RenameColumn(table: "dbo.integraDU", name: "Istallation_Requirements", newName: "ХОТЕЛКИ на МОНТАЖА");
            RenameColumn(table: "dbo.integraDU", name: "IntoProductionDate", newName: "Дата передачи в производство");
            RenameColumn(table: "dbo.integraDU", name: "CoordinationDate", newName: "Дата согласования");
            RenameColumn(table: "dbo.integraDU", name: "LetterIn", newName: "Наличие ответа вход");
            RenameColumn(table: "dbo.integraDU", name: "LetterOutData", newName: "Дата исх письма");
            RenameColumn(table: "dbo.integraDU", name: "LetterOutNumber", newName: "номер исх письма");
            RenameColumn(table: "dbo.integraDU", name: "DirectorPosition", newName: "Должность руководителя");
            RenameColumn(table: "dbo.integraDU", name: "Director", newName: "Руководитель ФИО");
            RenameColumn(table: "dbo.integraDU", name: "Contacts", newName: "Контактные данные");
            RenameColumn(table: "dbo.integraDU", name: "Foto", newName: "Тип съёмки");
            RenameColumn(table: "dbo.integraDU", name: "WallType", newName: "Тип стен");
            RenameColumn(table: "dbo.integraDU", name: "BTITarget", newName: "БТИ - Назначение");
            RenameColumn(table: "dbo.integraDU", name: "BTIWallType", newName: "БТИ - Тип стен");
        }
    }
}
