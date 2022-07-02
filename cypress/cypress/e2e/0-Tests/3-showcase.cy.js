import LoginPage from "../../pages/login.js"
import ProductsPage from "../../pages/products.js"
import ShowcasePage from "../../pages/showcase.js"

var loginPage = new LoginPage();
var productsPage = new ProductsPage();
var showcasePage = new ShowcasePage();

console.clear()
describe("Funcionalidade: Testes de validação da página de um produto específico",()=>{
    beforeEach(() => {
        loginPage.realizeLogin("standard_user", "secret_sauce");

        productsPage.checkIfBannerExist('Products');
    })

    it("Copiar todos os valores da tela de produtos",()=>{
        productsPage.getAllLabelPrices();
    });

    it("Verificar o preço de um produto da lista com o preço dele na vitrine", function(){
        let productsToAssert = 3;
        let LabelPrices = [this.ProductsLabelPrices, /(?=\$)/];
        
        productsPage.clickToEnterProductShowcase(productsToAssert, LabelPrices[0], LabelPrices[1]);

        showcasePage.checkIfBannerExist('Back to products');
        showcasePage.assertPriceInProductPageAndShowcasePage(productsToAssert, LabelPrices[0], LabelPrices[1]);
    })

    it("Verificar o preço de um ou mais produtos da lista com o preço dos mesmos na vitrine", function(){
        let productsToAssert = [1, 6, 2];
        let LabelPrices = [this.ProductsLabelPrices, /(?=\$)/];

        productsPage.clickToEnterProductShowcase(productsToAssert, LabelPrices[0], LabelPrices[1]);

        showcasePage.checkIfBannerExist('Back to products');
        showcasePage.assertPriceInProductPageAndShowcasePage(productsToAssert, LabelPrices[0], LabelPrices[1]);
    })

    it("Verificar o preço de todos os produtos da lista com o preço dos mesmos na vitrine", function(){
        let productsToAssert = 'all';
        let LabelPrices = [this.ProductsLabelPrices, /(?=\$)/];

        productsPage.clickToEnterProductShowcase(productsToAssert, LabelPrices[0], LabelPrices[1]);

        showcasePage.checkIfBannerExist('Back to products');
        showcasePage.assertPriceInProductPageAndShowcasePage(productsToAssert, LabelPrices[0], LabelPrices[1]);
    })
});