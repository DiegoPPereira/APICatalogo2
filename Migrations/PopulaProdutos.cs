using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    /// <inheritdoc />
    public partial class PopulaProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Produtos (Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId )" + 
                "VALUES('Coca-Cola Diet','Sem proteínas, gorduras ou fibra significativas. Valores diários baseados em uma dieta de 2000 kcal ou 8400 kj.',6.50,'cocacola.jpg',50,now(),1)");

            migrationBuilder.Sql("INSERT INTO Produtos (Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId )" +
                "VALUES('Torta de Atum','Torta de Atum 1000kg.',11.55,'torta.jpg',150,now(),2)");

            migrationBuilder.Sql("INSERT INTO Produtos (Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId )" +
                "VALUES('Bolo','bolo de cenoura 250kg.',10.75,'bolo.jpg',550,now(),3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Produtos");
        }
    }
}
