import CartPage from "../../pages/cart.js"
import LoginPage from "../../pages/login.js"
import ProductsPage from "../../pages/products.js"
import CheckoutPage from "../../pages/checkout_informations.js"
import CheckoutOverview from "../../pages/checkout_overview.js"
import CheckoutComplete from "../../pages/checkout_complete.js"

var cartPage = new CartPage();
var loginPage = new LoginPage();
var productsPage = new ProductsPage();
var checkoutPage = new CheckoutPage();
var checkoutOverview = new CheckoutOverview();
var checkoutComplete = new CheckoutComplete();

console.clear()
describe("Funcionalidade: Testes de adicionar e remover produtos no carrinho", function(){
    beforeEach(() => {
        loginPage.realizeLogin("standard_user", "secret_sauce");

        productsPage.checkIfBannerExist('Products');
    })

    it("Adicionar e depois remover produtos no carrinho", function(){
        productsPage.AddProductsToCart([1, 3, 4, 5]);
        productsPage.goToCart();

        cartPage.checkIfBannerExist('Your Cart');
        cartPage.removeItensFromCart([1, 3]);
        cartPage.checkQuantityInCartBadgeAndCartItens();
    });

    it("Adicionar produtos, continuar compra e voltar ao carrinho", function(){
        productsPage.AddProductsToCart([1, 3, 4]);
        productsPage.goToCart();

        cartPage.checkIfBannerExist('Your Cart');
        cartPage.removeItensFromCart([1]);
        cartPage.checkQuantityInCartBadgeAndCartItens();
        cartPage.goToCheckout();

        checkoutPage.checkIfBannerExist('Checkout: Your Information');
        checkoutPage.backToCart();
    });

    it("Adicionar produtos, continuar compra e deixar campo 'First Name' em branco", function(){
        productsPage.AddProductsToCart([1, 3, 4]);
        productsPage.goToCart();

        cartPage.checkIfBannerExist('Your Cart');
        cartPage.removeItensFromCart([1]);
        cartPage.checkQuantityInCartBadgeAndCartItens();
        cartPage.goToCheckout();

        checkoutPage.checkIfBannerExist('Checkout: Your Information');
        checkoutPage.typeInformationsAndContinueCheckout('', 'Hugo', '18007-234');
        checkoutPage.assertErrorShould('have.text', 'Error: First Name is required');
    });

    it("Adicionar produtos, continuar compra e deixar campo 'Last Name' em branco", function(){
        productsPage.AddProductsToCart([1, 3, 4]);
        productsPage.goToCart();

        cartPage.checkIfBannerExist('Your Cart');
        cartPage.removeItensFromCart([1]);
        cartPage.checkQuantityInCartBadgeAndCartItens();
        cartPage.goToCheckout();

        checkoutPage.checkIfBannerExist('Checkout: Your Information');
        checkoutPage.typeInformationsAndContinueCheckout('Jeferson', '', '45286-324');
        checkoutPage.assertErrorShould('have.text', 'Error: Last Name is required');
    });

    it("Adicionar produtos, continuar compra e deixar campo 'Zip/Postal Code Name' em branco", function(){
        productsPage.AddProductsToCart([1, 3, 4]);
        productsPage.goToCart();

        cartPage.checkIfBannerExist('Your Cart');
        cartPage.removeItensFromCart([1]);
        cartPage.checkQuantityInCartBadgeAndCartItens();
        cartPage.goToCheckout();

        checkoutPage.checkIfBannerExist('Checkout: Your Information');
        checkoutPage.typeInformationsAndContinueCheckout('Jeferson', 'Hugo', '');
        checkoutPage.assertErrorShould('have.text', 'Error: Postal Code is required');
    });

    it("Adicionar produtos, continuar compra e voltar a página de produtos", function(){
        productsPage.AddProductsToCart([1, 3, 4]);
        productsPage.goToCart();

        cartPage.checkIfBannerExist('Your Cart');
        cartPage.removeItensFromCart([1]);
        cartPage.checkQuantityInCartBadgeAndCartItens();
        cartPage.goToCheckout();

        checkoutPage.checkIfBannerExist('Checkout: Your Information');
        checkoutPage.typeInformationsAndContinueCheckout('Jeferson', 'Hugo', '40028-922');
        
        checkoutOverview.checkIfBannerExist('Checkout: Overview');
        checkoutOverview.backToProductsPage();
    });

    it("Adicionar produtos, finalizar a compra e verificar quantidade de itens no carrinho", function(){
        productsPage.AddProductsToCart([1, 3, 4]);
        productsPage.goToCart();

        cartPage.checkIfBannerExist('Your Cart');
        cartPage.removeItensFromCart([1]);
        cartPage.checkQuantityInCartBadgeAndCartItens();
        cartPage.goToCheckout();

        checkoutPage.checkIfBannerExist('Checkout: Your Information');
        checkoutPage.typeInformationsAndContinueCheckout('Jeferson', 'Hugo', '40028-922');

        checkoutOverview.checkIfBannerExist('Checkout: Overview');
        checkoutOverview.finishPurchase();
    
        checkoutComplete.checkIfBannerExist('Checkout: Complete!');
        checkoutComplete.backToProductsPage();

        productsPage.assertQuantityProductsInCartBadge(0);
    });

    // it("Teste 1", function(){
    //     productsPage.AddProductsToCart('all');
    //     productsPage.goToCart();
    //     cartPage.goToCheckout();
    //     checkoutPage.typeInformationsAndContinueCheckout('Jeferson', 'Hugo', '40028-922');
    //     checkoutOverview.getAllLabelPrices();
    // });

    // it("Teste 2", function(){
    //     let productsToAddInCart = [1, 3, 4]
    //     let LabelPrices = [this.CheckoutLabelPrices, /(?=\$)/];

    //     productsPage.AddProductsToCart(productsToAddInCart);
    //     productsPage.goToCart();
    //     cartPage.goToCheckout();
    //     checkoutPage.typeInformationsAndContinueCheckout('Jeferson', 'Hugo', '40028-922');
    //     checkoutOverview.checkTotalPrice(productsToAddInCart, LabelPrices[0], LabelPrices[1]);
    // });
});