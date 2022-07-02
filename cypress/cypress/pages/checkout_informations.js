class CheckoutPage {
    //SELECTORS OF ELEMENTS
    lblBanner = '.title';
    btnCancel = '[data-test="cancel"]';
    btnContinueCheckout = '[data-test="continue"]';
    txtFirstName = '[data-test="firstName"]';
    txtLastName = '[data-test="lastName"]';
    txtPostalCode = '[data-test="postalCode"]';
    lblError = '[data-test="error"]';

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

    clickContinueCheckout() {
        cy.get(this.btnContinueCheckout).click();
    }

    typeFirstName(firstname) {
        if (firstname) cy.get(this.txtFirstName).type(firstname);
    }

    typeLastName(lastname) {
        if (lastname) cy.get(this.txtLastName).type(lastname);
    }

    typePostalCode(postalcode) {
        if (postalcode) cy.get(this.txtPostalCode).type(postalcode);
    }

    assertErrorShould(chainer, value) {
        cy.get(this.lblError).should(chainer, value);
    }

    //FUNCTIONALITIES
    checkIfBannerExist(bannerText) {
        this.assertBannerText(bannerText);
    }

    backToCart() {
        cy.get(this.btnCancel).click();
    }

    typeInformationsAndContinueCheckout(firstName, lastName, postalCode) {
        this.typeFirstName(firstName);
        this.typeLastName(lastName);
        this.typePostalCode(postalCode);
        this.clickContinueCheckout();
    }
    
}

export default CheckoutPage;