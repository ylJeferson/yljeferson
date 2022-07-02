class CheckoutOverview {
    //SELECTORS OF ELEMENTS
    lblBanner = '.title';
    lblPrice = '.inventory_item_price';
    btnCancel = '[data-test="cancel"]';
    btnFinishCheckout = '[data-test="finish"]';
    summaryInfo = '.summary_info';
    lblPrice = '.inventory_item_price'
    ItemTotal = '.summary_subtotal_label'
    Tax = '.summary_tax_label'
    Total = '.summary_total_label'

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

    clickCancel() {
        cy.get(this.btnCancel).click();
    }

    clickFinishCheckout() {
        cy.get(this.btnFinishCheckout).click();
    }

    getAllLabelPrices() {
        cy.xpath('//div[@class="inventory_item_price"]').each(() => {
            return 'nothing'
        }).invoke('text').as('CheckoutLabelPrices')
    }

    //FUNCTIONALITIES
    checkIfBannerExist(bannerText) {
        this.assertBannerText(bannerText);
    }

    backToProductsPage() {
        this.clickCancel();
    }

    finishPurchase() {
        this.clickFinishCheckout();
    }

    checkPriceValues(products, valuePrices, regex) {
        let total = 0;
        let totalFrete = 0;
        let totalProdutos = 0;
        let CheckoutPrices = valuePrices.split(regex);
        var y = CheckoutPrices.map(s => s.slice(1));

        for(var i = 0; i < y.length; i++) {
            let productInCart = products.filter(item => item == i + 1)
            if (productInCart.length == 1) {
                    totalProdutos += parseFloat(y[i]);
            }
        }

        totalFrete = Math.round(totalProdutos / 10 * .8 * 100) / 100
        total = totalProdutos + totalFrete

        cy.get(this.ItemTotal).invoke('text').should('eq', `Item total: $${totalProdutos}`)
        cy.get(this.Tax).invoke('text').should('eq', `Tax: $${totalFrete}`)
        cy.get(this.Total).invoke('text').should('eq', `Total: $${total}`)
    }
}

export default CheckoutOverview;
