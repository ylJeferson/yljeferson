class CartPage {
    //SELECTORS OF ELEMENTS
    lblBanner = '.title';
    btnContinueShopping = '#continue-shopping';
    btnCart = '.shopping_cart_link';
    lblItensInCart = '//*[@class="cart_list"]/div';
    lblQuantityCartBadge = ''

    //ACTIONS
    assertBannerText(bannerText) {
        cy.get(this.lblBanner).then((e) => {
            if (bannerText != e.text()) {
                throw new Error('The page you are trying to access was not found!');
            } else {
                cy.log({message: `The text '${bannerText}' was found!`})
            }
        })
    }

    clickContinueShopping() {
        cy.get(this.btnContinueShopping).click();
    }
    
    assertQuantityProductsInCart() {
        let qttInCartBadge = 0;
        let qttInCartItens = 1;

        cy.get(this.btnCart).then((e) => {
            if (!e.find('span').length) {
                cy.log('There are no items in the cart!');
            } else {
                qttInCartBadge = e.find('span').text();

                cy.xpath(this.lblItensInCart).should((e) => {
                    qttInCartItens = e.length;
                })
        
                if (!this.qttInCartItens === this.qttInCartBadge) {
                    throw new Error('The quantity of items in the cart and in the item list is different!');
                } else {
                    cy.log('The quantity of items in the cart and in the item list are the same!');
                }
            }
        })
    }

    clickToRemoveItensFromCart(products) {
        cy.xpath(this.lblItensInCart).then((e) => {
            if (e.find('button').length) {
                let i = 0;
    
                while (i < e.find('button').length) {
                    if (products == 'all') {
                        let clickButton = '[data-test="' + e.find('button')[i].id + '"]';
                        cy.get(`${clickButton}`).click();
                        cy.log(`The product ${e.find('button')[i].id.split('remove-').pop()} has been removed from the cart!`);
                    } else {
                        let productsToRemove = products.map(function(value) {
                            return value - 1; 
                        })
    
                        if (productsToRemove.includes(i))  {
                            let clickButton = '[data-test="' + e.find('button')[i].id + '"]';
                            cy.get(`${clickButton}`).click();
                            cy.log(`The product ${e.find('button')[i].id.split('remove-').pop()} has been removed from the cart!`);
                        }
                    }
                    
                    i++;
                }
            }
        })
    }

    goToCheckout() {
        cy.get('[data-test="checkout"]').click();
    }

    //FUNCTIONALITIES
    checkIfBannerExist(bannerText) {
        this.assertBannerText(bannerText);
    }

    goToProducts() {
        this.clickContinueShopping();
    }

    checkQuantityInCartBadgeAndCartItens() {
        this.assertQuantityProductsInCart();
    }

    removeItensFromCart(products) {
        this.clickToRemoveItensFromCart(products);
    }
}

export default CartPage;