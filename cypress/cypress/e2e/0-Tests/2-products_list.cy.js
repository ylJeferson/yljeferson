import LoginPage from "../../pages/login.js"
import ProductsPage from "../../pages/products.js"

var loginPage = new LoginPage();
var productsPage = new ProductsPage();

console.clear()
describe("Funcionalidade: Página da Lista com os Produtos",()=>{
    beforeEach(() => {
        loginPage.realizeLogin("standard_user", "secret_sauce");

        productsPage.checkIfBannerExist('Products');
    })

    it("Adicionar um produto ao carrinho",()=>{
        productsPage.AddProductsToCart([3]);
    });

    it("Adicionar um produto fora do índice",()=>{
        productsPage.AddProductsToCart([10]);
    });

    it("Adicionar um produto depois todos o outros da lista ao carrinho",()=>{
        productsPage.AddProductsToCart([1, 3, 6, 5]);
        productsPage.AddProductsToCart('all');
    });

    it("Adicionar todos os produtos depois adicionar um produto específico",()=>{
        productsPage.AddProductsToCart('all');    
        productsPage.AddProductsToCart([5]);
    });

    it("Adicionar todos os produtos e remover um específico",()=>{
        productsPage.AddProductsToCart('all');
        productsPage.RemoveProductsOfCart([5]);
    });

    it("Adicionar todos os produtos e remover todos",()=>{
        productsPage.AddProductsToCart('all');
        productsPage.RemoveProductsOfCart('all');
    });

    it("Verificar ordenação dos produtos (A-Z)",()=>{
        productsPage.orderProducts('az');
        productsPage.verifyIfOrderIsCorrect('az');
    });

    it("Verificar ordenação dos produtos (Z-A)",()=>{
        productsPage.orderProducts('za');
        productsPage.verifyIfOrderIsCorrect('za');
    });

    it("Verificar ordenação dos produtos (Preço Crescente)",()=>{
        productsPage.orderProducts('lohi');
        productsPage.verifyIfOrderIsCorrect('lohi');
    });

    it("Verificar ordenação dos produtos (Preço Decrescente)",()=>{
        productsPage.orderProducts('hilo');
        productsPage.verifyIfOrderIsCorrect('hilo');
    });
});