import LoginPage from "../../pages/login.js"
import ProductsPage from "../../pages/products.js"

var loginPage = new LoginPage();
var productsPage = new ProductsPage();

console.clear();
describe("Funcionalidade: Testes de login",()=>{
    it("Login com sucesso",()=>{
        loginPage.realizeLogin("standard_user", "secret_sauce");

        productsPage.checkIfBannerExist('Products');
    });
    
    it("Erro no usuario",()=>{
        loginPage.realizeLogin("vish", "secret_sauce");
        loginPage.assertErrorShould("contain.text", "Username and password do not match");
    });
    
    it("Erro na senha",()=>{
        loginPage.realizeLogin("standard_user", "deu ruim");
        loginPage.assertErrorContains("Username and password do not match");
    });
});