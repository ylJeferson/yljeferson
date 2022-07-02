import CartPage from "../../pages/cart.js"
import LoginPage from "../../pages/login.js"
import ProductsPage from "../../pages/products.js"

var cartPage = new CartPage();
var loginPage = new LoginPage();
var productsPage = new ProductsPage();

console.clear()
describe("Funcionalidade: Página do login",()=>{
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

describe("Funcionalidade: Página da Lista com os Produtos",()=>{
    beforeEach(() => {
        loginPage.realizeLogin("standard_user", "secret_sauce");

        productsPage.checkIfBannerExist('Products');
    })

    it("Adicionar um produto ao carrinho",()=>{
        productsPage.AddProductsToCart([3]);
        productsPage.verifyQuantityOfProductsInCartBadge();
    });

    it("Adicionar um produto fora do índice",()=>{
        productsPage.AddProductsToCart([10]);
        productsPage.verifyQuantityOfProductsInCartBadge();
    });

    it("Adicionar um produto depois todos o outros da lista ao carrinho",()=>{
        productsPage.AddProductsToCart([1, 3, 6, 5]);
        productsPage.AddProductsToCart('all');
        productsPage.verifyQuantityOfProductsInCartBadge();
    });

    it("Adicionar todos os produtos depois adicionar um produto específico",()=>{
        productsPage.AddProductsToCart('all');    
        productsPage.AddProductsToCart([5]);
        productsPage.verifyQuantityOfProductsInCartBadge();
    });

    it("Adicionar todos os produtos e remover um específico",()=>{
        productsPage.AddProductsToCart('all');
        productsPage.RemoveProductsOfCart([5]);
        productsPage.verifyQuantityOfProductsInCartBadge();
    });

    it("Adicionar todos os produtos e remover todos",()=>{
        productsPage.AddProductsToCart('all');
        productsPage.RemoveProductsOfCart('all');
        productsPage.verifyQuantityOfProductsInCartBadge();
    });

    it("Verificar Ordenação dos produtos (A-Z)",()=>{
        productsPage.orderProducts('az');
        productsPage.verifyIfOrderIsCorrect('az');
    });

    it("Verificar Ordenação dos produtos (Z-A)",()=>{
        productsPage.orderProducts('za');
        cy.wait(500)
        productsPage.verifyIfOrderIsCorrect('za');
    });

    it("Verificar Ordenação dos produtos (Preço Crescente)",()=>{
        productsPage.orderProducts('lohi');
        productsPage.verifyIfOrderIsCorrect('lohi');
    });

    it("Verificar Ordenação dos produtos (Preço Decrescente)",()=>{
        productsPage.orderProducts('hilo');
        productsPage.verifyIfOrderIsCorrect('hilo');
    });
});

// describe("Funcionalidade: Página do Produto",()=>{
//     it("Adicionar/Remover produtos ao carrinho na página de um produto especifico",()=>{
//         loginPage.realizeLogin("standard_user", "secret_sauce");

//         productsPage.checkIfBannerExist('Products');
//     });
// });

describe("Funcionalidade: Página do Carrinho",()=>{
    // before(() => {
    //     loginPage.realizeLogin("standard_user", "secret_sauce");

    //     productsPage.checkIfBannerExist('Products');
    //     productsPage.goToCart();
    // })

    // beforeEach(() => {
    //     cartPage.goToProducts();
    //     productsPage.checkIfBannerExist('Products');
    //     productsPage.RemoveProductsOfCart('all');
    // })

    beforeEach(() => {
        loginPage.realizeLogin("standard_user", "secret_sauce");

        productsPage.checkIfBannerExist('Products');
    })
    
    it("Remover um produto adicionado",()=>{
        productsPage.AddProductsToCart([1, 4, 6]);
        productsPage.goToCart();

        cartPage.checkIfBannerExist('Your Cart');
        cartPage.removeItensFromCart([3]);
        cartPage.checkQuantityInCartBadgeAndCartItens();
    });
    
    it("Remover um produto e depois todos os outros que foram adicionados",()=>{
        productsPage.AddProductsToCart([1, 4]);
        productsPage.goToCart();

        cartPage.checkIfBannerExist('Your Cart');
        cartPage.removeItensFromCart([3]);
        cartPage.checkQuantityInCartBadgeAndCartItens();
        cartPage.removeItensFromCart('all');
        cartPage.checkQuantityInCartBadgeAndCartItens();
    });

    it("Remover sem adicionar produtos",()=>{
        productsPage.goToCart();

        cartPage.checkIfBannerExist('Your Cart');
        cartPage.removeItensFromCart('all');
        cartPage.checkQuantityInCartBadgeAndCartItens();
    });

    it("Verificar a quantidade de produtos adicionados",()=>{
        productsPage.AddProductsToCart([2, 3, 6]);
        productsPage.goToCart();

        cartPage.checkIfBannerExist('Your Cart');
        cartPage.checkQuantityInCartBadgeAndCartItens();
    });

    it("Verificar a quantidade no carrinho adicionando dois produtos e depois o restante",()=>{
        productsPage.AddProductsToCart([2, 3]);
        productsPage.goToCart();

        cartPage.checkIfBannerExist('Your Cart');
        cartPage.checkQuantityInCartBadgeAndCartItens();
        cartPage.goToProducts();

        productsPage.AddProductsToCart('all');
        productsPage.goToCart();

        cartPage.checkIfBannerExist('Your Cart');
        cartPage.checkQuantityInCartBadgeAndCartItens();
    });

    it("Verificar a quantidade sem produtos adicionados",()=>{
        productsPage.goToCart();

        cartPage.checkIfBannerExist('Your Cart');
        cartPage.checkQuantityInCartBadgeAndCartItens();
    });

    it("Continuar comprando",()=>{
        // cartPage.goToProducts();
    });
});

// ------------------------------------------------
// -----> CODIGOS PARA POSSIVEL REUTILIZACAO <-----
// ------------------------------------------------

// return cy.log({
//     name: 'TESTE',
//     message: cy.xpath(this.btnCart)
// })
    
// getDivChildren() {
//     cy.get(this.divProductsList).each((e) => {
//         console.log(e[0].children[1].children[1].children[0].innerHTML);
//         console.log(e[0].children[1].children[1].children[1].innerHTML);
//     });
// }

// cy.xpath(this.divProductsList).each((e, i) => {
//     i++;
//     nextButton = cy.xpath(this.divProductsList + '[' + i + ']//button');

//     nextButton.then((e) => {
//         if (e.text() === 'Add to cart') {
//             nextButton.click();
//             buttonClicked++;
//             this.lblQuantityCartBadge++;
//         }
//     })
// });



// it("Test 1", () => {
//     cy.get('.inventory_item_price').invoke('text').as('article')
// })
    
//     //Now you can use this.article in all the other test cases
//     //If you are using aliases remember Not to use arrow functions on hooks
    
// it("Test 2", function(){
//     //this will log Backpack
//     cy.log(this.article)
// })

// clickToEnterProductShowcase(Products, AddOrRemove) {
//     cy.xpath(this.divProductsList + '//img').then((e) => {
//         let i = 0;

//         while (i < e.length) {
//             i++;
//             cy.xpath(this.divProductsList + '[' + i + ']//img').click();
//         }
//     })
// }


// getAllLabelPrice() {
//     cy.xpath(this.divProductsList + '//div[@class="inventory_item_price"]').then((e) => {
//         this.lblPrice = e.text().split("$")
//         console.log(this.lblPrice.splice(0, 0))
//     })
// }

// cy.wrap([1, 2, 3]).each((num, i, array) => {
//     return new Cypress.Promise((resolve) => {
//       setTimeout(() => {
//         resolve()
//       }, num * 100)
//     })
//   })