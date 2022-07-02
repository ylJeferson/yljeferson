class CheckoutComplete {
    //SELECTORS OF ELEMENTS
    lblBanner = '.title';
    btnCancel = '[data-test="back-to-products"]';

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

    clickBackHome() {
        cy.get(this.btnCancel).click();
    }

    //FUNCTIONALITIES
    checkIfBannerExist(bannerText) {
        this.assertBannerText(bannerText);
    }

    backToProductsPage() {
        this.clickBackHome();
    }    
}

export default CheckoutComplete;