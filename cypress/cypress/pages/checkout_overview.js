class CheckoutOverview {
    //SELECTORS OF ELEMENTS
    lblBanner = '.title';
    lblPrice = '.inventory_item_price';
    btnCancel = '[data-test="cancel"]';
    btnFinishCheckout = '[data-test="finish"]';
    summaryInfo = '.summary_info';
    lblPrice = '.inventory_item_price'

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

    getItemsPrices() {

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

    checkTotalPrice(products, valuePrices, regex) {
        let soma = 0;
        let CheckoutPrices = valuePrices.split(regex);

        console.log(CheckoutPrices);

        var y = CheckoutPrices.map(s => s.slice(1).replace('.', ','));

        console.log(y);

        soma = y[0] + y[1];
        console.log(soma)

        // console.log(y.reduce((total, produto) => total + produto.preco));


        // for(var i = 0; i < CheckoutPrices.length; i++) {
        //     soma += CheckoutPrices[i];
        // }
        // console.log(soma);
    }
}

export default CheckoutOverview;