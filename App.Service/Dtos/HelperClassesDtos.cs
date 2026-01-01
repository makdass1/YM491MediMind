namespace App.Service.Dtos
{
    // Medicines tablosu için
    public class MedicineDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }


    public class FrequencyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }


    public class AllergyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

   
    public class UserAllergyDto
    {
        public int UsersId { get; set; }
        public int AllergiesId { get; set; }
    }
}