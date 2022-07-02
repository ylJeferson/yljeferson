class LoginPage {
    //SELECTORS OF ELEMENTS
    urlSite = 'https://www.saucedemo.com';

    txtUsername = '[data-test="username"]';
    txtPassword = '//input[@id="password"]';
    btnLogin = '[data-test="login-button"]';
    lblError = '[data-test="error"]';

    //ACTIONS
    typeUsername(username) {
        cy.get(this.txtUsername).type(username);
    }

    typePassword(password) {
        cy.xpath(this.txtPassword).type(password);
    }

    clickLogin() {
        cy.get(this.btnLogin).click();
    }

    assertErrorShould(chainer, value) {
        cy.get(this.lblError).should(chainer, value);
    }

    assertErrorContains(text) {
        cy.get(this.lblError).contains(text);
    }

    //FUNCTIONALITIES
    realizeLogin(username, password) {
        cy.visit(this.urlSite);
        this.typeUsername(username);
        this.typePassword(password);
        this.clickLogin();
    }
}

export default LoginPage;