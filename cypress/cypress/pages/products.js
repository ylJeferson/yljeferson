class ProductsPage {
    //SELECTORS OF ELEMENTS
    lblBanner = '.title';
    divProductsList = '//*[@class="inventory_list"]/div';
    btnCart = '.shopping_cart_link';
    slcOrder = '.product_sort_container';
    optOrder = ['az', 'za', 'lohi', 'hilo'];

    //ACTIONS
    assertBannerText(bannerText) {
        cy.get(this.lblBanner).then((e) => {
            if (bannerText != e.text()) {
                throw new Error('The page you are trying to access was not found!');
            } else {
                cy.log({message: `The text '${bannerText}' was found!`})
            }
        });
    }

    assertQuantityProductsAddedToCart() {
        cy.xpath(this.divProductsList).then((e) => {
            this.assertQuantityProductsInCartBadge(e.find('button:contains("Remove")').length)
        })
    }

    assertQuantityProductsInCartBadge(actualQuantity) {
        cy.get(this.btnCart).then((e) => {
            if (e.find('span').text() != actualQuantity) {
                throw new Error('The quantity of items in the cart is different from the quantity of items added!');
            } else {
                cy.log({message: `There is(are) ${actualQuantity} product(s) in cart!`})
            }
        })
    }

    assertOrderOfProductsList(option) {
        let i = 0;
        let arrSequence = [];
        let arrSequenceSorted = [];
        let slcOrderNameOrPrice = '';
        let AscOrDesc = '';

        if (option == 'az' || option == 'za') {
            slcOrderNameOrPrice = '//div[@class="inventory_item_name"]';
        } else if (option == 'lohi' || option == 'hilo') {
            slcOrderNameOrPrice = '//div[@class="inventory_item_price"]';
        } else {
            throw new Error('Please select an option existing in checkbox!');
        }

        if (option == 'az' || option == 'lohi') {
            AscOrDesc = function(a, b){return a-b};
        } else if (option == 'za' || option == 'hilo') {
            AscOrDesc = function(a, b){return b-a};
        }

        cy.xpath(this.divProductsList + slcOrderNameOrPrice).then((e) => {
            while (i < e.length) {
                arrSequence.push(e[i].innerHTML);
                arrSequenceSorted.push(e[i].innerHTML);
                i++;
            }

            arrSequenceSorted.sort(AscOrDesc)
            for (let i = 0; i < arrSequence.length; i++) {
                if (arrSequence[i] != arrSequenceSorted[i]) {
                    throw new Error('Elements are not in alphabetical order! (A-Z)');
                } else {
                    cy.log({message: 'The data are in the same sort order!'})
                }
            }
        })
    }

    clickAddToCartOrRemove(Products, AddOrRemove) {
        cy.xpath(this.divProductsList + '//button').then((e) => {
            let i = 0;

            while (i < e.length) {
                i++;
                var actualItem = i - 1;

                if (Products == 'all' && e[actualItem].innerHTML == AddOrRemove || Products.includes(i) && e[actualItem].innerHTML == AddOrRemove) {
                    cy.xpath(this.divProductsList + '[' + i + ']//button').click();
                }
            }
        })
    }

    clickToOrderProducts(options) {
        cy.get(this.slcOrder).select(options);
    }

    clickCart() {
        cy.get(this.btnCart).click();
    }

    getAllLabelPrices() {
        cy.xpath(this.divProductsList + '//div[@class="inventory_item_price"]').each(() => {
            return 'nothing'
        }).invoke('text').as('ProductsLabelPrices')
    }

    clickToEnterProductShowcase(index, valuePrices, regex) {
        let ProductPagePrice = valuePrices.split(regex);

        if (typeof(index) == 'number' && index <= ProductPagePrice.length) {
            cy.xpath(this.divProductsList + '[' + index + ']//img').click();
        } else if (typeof(index) == 'object' && index.length <= ProductPagePrice.length) {
            cy.xpath(this.divProductsList + '[' + index[0] + ']//img').click();
        } else if (index == 'all') {
            cy.xpath(this.divProductsList + '[' + 1 + ']//img').click();
        } else {
            throw new Error('The added parameter does not correspond to the command, you must add a number, an array with values ​​corresponding to the number of items on the products page or use the "all" option!');
        }
    }
    
    //FUNCTIONALITIES
    checkIfBannerExist(bannerText) {
        this.assertBannerText(bannerText);
    }

    AddProductsToCart(products) {
        this.clickAddToCartOrRemove(products, 'Add to cart');
    }

    RemoveProductsOfCart(products) {
        this.clickAddToCartOrRemove(products, 'Remove');
    }

    goToCart() {
        this.clickCart();
    }

    orderProducts(option) {
        this.clickToOrderProducts(option);
    }

    verifyIfOrderIsCorrect(option) {
        this.assertOrderOfProductsList(option);
    }

    verifyQuantityOfProductsInCartBadge() {
        this.assertQuantityProductsAddedToCart(this.lblQuantityCartBadge);
    }
}

export default ProductsPage;