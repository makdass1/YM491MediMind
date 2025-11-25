using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace App.Repository.Migrations
{
    /// <inheritdoc />
    public partial class SeedAllergyAndChronicDiseases : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Aspirin Alerjisi");

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Çilek Alerjisi");

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Fıstık Alerjisi");

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Gluten Alerjisi");

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "İyot Alerjisi");

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Kabuklu Deniz Ürünleri Alerjisi");

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Kakao Alerjisi");

            migrationBuilder.InsertData(
                table: "Allergies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 8, "Küf Mantarı Alerjisi" },
                    { 9, "Lateks Alerjisi" },
                    { 10, "Mantar Alerjisi" },
                    { 11, "Morfin Alerjisi" },
                    { 12, "Nikel Alerjisi" },
                    { 13, "Penisilin Alerjisi" },
                    { 14, "Polen Alerjisi" },
                    { 15, "Süt Ürünleri Alerjisi" },
                    { 16, "Soya Alerjisi" },
                    { 17, "Şeftali Alerjisi" },
                    { 18, "Tuzlu Su Balıkları Alerjisi" },
                    { 19, "Vanilya Alerjisi" },
                    { 20, "Yumurta Alerjisi" },
                    { 21, "Yer Fıstığı Alerjisi" },
                    { 22, "Çam Pollen Alerjisi" },
                    { 23, "Fındık Alerjisi" },
                    { 24, "Kaju Alerjisi" },
                    { 25, "Keten Tohumu Alerjisi" },
                    { 26, "Kuruyemiş Karışımı Alerjisi" },
                    { 27, "Lavanta Alerjisi" },
                    { 28, "Mercimek Alerjisi" },
                    { 29, "Mısır Alerjisi" },
                    { 30, "Okyanus Balıkları Alerjisi" },
                    { 31, "Pirinç Alerjisi" },
                    { 32, "Sarımsak Alerjisi" },
                    { 33, "Sedef Hastalığına Bağlı Alerji" },
                    { 34, "Somon Balığı Alerjisi" },
                    { 35, "Susam Alerjisi" },
                    { 36, "Tuzlu Su Karidesi Alerjisi" },
                    { 37, "Un Alerjisi" },
                    { 38, "Vanilya Fasulyesi Alerjisi" },
                    { 39, "Vişne Alerjisi" },
                    { 40, "Yaban Mersini Alerjisi" },
                    { 41, "Yeşil Mercimek Alerjisi" },
                    { 42, "Yosun Alerjisi" },
                    { 43, "Zencefil Alerjisi" },
                    { 44, "Zeytin Alerjisi" },
                    { 45, "Ev Tozu Akarı Alerjisi" },
                    { 46, "Kedi Tüyü Alerjisi" },
                    { 47, "Köpek Tüyü Alerjisi" },
                    { 48, "Saman Alerjisi" },
                    { 49, "Meyve Karışımı Alerjisi" },
                    { 50, "Sebze Karışımı Alerjisi" }
                });

            migrationBuilder.InsertData(
                table: "ChronicDiseasesses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Alzheimer" },
                    { 2, "Akciğer Kanseri" },
                    { 3, "Anemi (Kronik)" },
                    { 4, "Astım" },
                    { 5, "Böbrek Yetmezliği" },
                    { 6, "Crohn Hastalığı" },
                    { 7, "Diyabet" },
                    { 8, "Epilepsi" },
                    { 9, "Fibromiyalji" },
                    { 10, "Hiperkolesterolemi" },
                    { 11, "Hipertansiyon" },
                    { 12, "Hipotiroidi" },
                    { 13, "Hipertiroidi" },
                    { 14, "Kalp Yetmezliği" },
                    { 15, "Kanser" },
                    { 16, "Kolorektal Kanser" },
                    { 17, "KOAH" },
                    { 18, "Koroner Arter Hastalığı" },
                    { 19, "Kronik Akciğer Hastalığı" },
                    { 20, "Kronik Böbrek Hastalığı" },
                    { 21, "Kronik Depresyon" },
                    { 22, "Kronik Enfeksiyonlar (HIV, Hepatit B/C)" },
                    { 23, "Kronik Göz Hastalıkları (Glokom, Katarakt)" },
                    { 24, "Kronik Karaciğer Hastalığı" },
                    { 25, "Kronik Migren" },
                    { 26, "Kronik Pancreatit" },
                    { 27, "Kronik Sinüzit" },
                    { 28, "Kronik Yorgunluk Sendromu" },
                    { 29, "Kronik Dermatolojik Hastalıklar" },
                    { 30, "Lupus" },
                    { 31, "Meme Kanseri" },
                    { 32, "Migren" },
                    { 33, "Multipl Skleroz (MS)" },
                    { 34, "Multiple Myeloma" },
                    { 35, "Obezite" },
                    { 36, "Osteoartrit" },
                    { 37, "Parkinson" },
                    { 38, "Prostat Kanseri" },
                    { 39, "Psoriatik Artrit" },
                    { 40, "Romatoid Artrit" },
                    { 41, "Siroz" },
                    { 42, "Uyku Apnesi" },
                    { 43, "Pulmoner Fibroz" },
                    { 44, "Kronik Anksiyete" },
                    { 45, "Kronik Böbrek Yetmezliği" },
                    { 46, "Kronik Karaciğer Yetmezliği" },
                    { 47, "Kronik Panik Bozukluğu" },
                    { 48, "Kronik Romatizmal Hastalıklar" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "ChronicDiseasesses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ChronicDiseasesses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ChronicDiseasesses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ChronicDiseasesses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ChronicDiseasesses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ChronicDiseasesses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ChronicDiseasesses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ChronicDiseasesses",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ChronicDiseasesses",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ChronicDiseasesses",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ChronicDiseasesses",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ChronicDiseasesses",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ChronicDiseasesses",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ChronicDiseasesses",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ChronicDiseasesses",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ChronicDiseasesses",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ChronicDiseasesses",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ChronicDiseasesses",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ChronicDiseasesses",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ChronicDiseasesses",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ChronicDiseasesses",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ChronicDiseasesses",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ChronicDiseasesses",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ChronicDiseasesses",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ChronicDiseasesses",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ChronicDiseasesses",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ChronicDiseasesses",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ChronicDiseasesses",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ChronicDiseasesses",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ChronicDiseasesses",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ChronicDiseasesses",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ChronicDiseasesses",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ChronicDiseasesses",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ChronicDiseasesses",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ChronicDiseasesses",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ChronicDiseasesses",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "ChronicDiseasesses",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "ChronicDiseasesses",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "ChronicDiseasesses",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "ChronicDiseasesses",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "ChronicDiseasesses",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "ChronicDiseasesses",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "ChronicDiseasesses",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "ChronicDiseasesses",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "ChronicDiseasesses",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "ChronicDiseasesses",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "ChronicDiseasesses",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "ChronicDiseasesses",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Fıstık Alerjisi");

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Gluten Alerjisi");

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Süt Ürünleri Alerjisi");

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Çilek Alerjisi");

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Yumurta Alerjisi");

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Polen Alerjisi");

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Kakao");
        }
    }
}
