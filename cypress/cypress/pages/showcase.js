class ShowcasePage {
    //SELECTORS OF ELEMENTS
    lblBanner = '#back-to-products';
    lblPrice = '.inventory_details_price';
    divProductsList = '//*[@class="inventory_list"]/div';
    
    //ACTIONS
    checkIfBannerExist(bannerText) {
        cy.get(this.lblBanner).then((e) => {
            if (bannerText != e.text()) {
                console.log(e.text())
                throw new Error('The page you are trying to access was not found!');
            } else {
                cy.log({message: `The text '${bannerText}' was found!`})
            }
        });
    }

    clickToEnterProductShowcase(index, valuePrices, regex) {
        let ProductPagePrice = valuePrices.split(regex);

        if (typeof(index) == 'number' && index <= ProductPagePrice.length) {
            cy.xpath(this.divProductsList + '[' + index + ']//img').click();
        } else if (typeof(index) == 'object' && index.length <= ProductPagePrice.length) {
            cy.xpath(this.divProductsList + '[' + index[0] + ']//img').click();
        } else if (index == 'all') {
            cy.xpath(this.divProductsList + '[' + index[0] + ']//img').click();
        } else {
            throw new Error('The added parameter does not correspond to the command, you must add a number, an array with values ​​corresponding to the number of items on the products page or use the "all" option!');
        }
    }
    
    //FUNCTIONALITIES
    assertPriceInProductPageAndShowcasePage(index, valuePrices, regex) {
        let ProductPagePrice = valuePrices.split(regex);

        if (typeof(index) == 'number' && index <= ProductPagePrice.length) {
            if (cy.get(this.lblPrice).invoke('text').should('eq', ProductPagePrice[index - 1])) {
                cy.log({message: 'The value of the product is the same in the shop window and on the page!'})
            }

        } else if (typeof(index) == 'object' && index.length <= ProductPagePrice.length) {
            let i = 0;
            cy.get('[data-test="back-to-products"]').click();

            while (i < index.length) {
                cy.xpath(this.divProductsList + '[' + index[i] + ']//img').click();
                
                if (cy.get(this.lblPrice).invoke('text').should('eq', ProductPagePrice[index[i] - 1])) {
                    cy.log({message: 'The value of the product is the same in the shop window and on the page!'});
                }

                cy.get('[data-test="back-to-products"]').click();
                i++
            }

        } else if (index == 'all') {
            let i = 1;
            cy.get('[data-test="back-to-products"]').click();

            cy.xpath(this.divProductsList).then((e) => {
                index = e.length;
            
                while (i <= index) {
                    cy.xpath(this.divProductsList + '[' + i + ']//img').click();
                    
                    if (cy.get(this.lblPrice).invoke('text').should('eq', ProductPagePrice[i - 1])) {
                        cy.log({message: 'The value of the product is the same in the shop window and on the page!'});
                    }
    
                    cy.get('[data-test="back-to-products"]').click();
                    i++
                }
            })

        } else {
            throw new Error('The added parameter does not correspond to the command, you must add a number, an array with values ​​corresponding to the number of items on the products page or use the "all" option!');
        }
    }
}

export default ShowcasePage;