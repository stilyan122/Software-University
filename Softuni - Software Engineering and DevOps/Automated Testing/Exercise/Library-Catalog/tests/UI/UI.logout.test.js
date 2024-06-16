const {test, expect} = require('@playwright/test');

test('Verify that the "Logout" button is visible', async ({page}) => {
    await page.goto('http://localhost:3000/login');
    await page.fill('input[name="email"]', 'peter@abv.bg');
    await page.fill('input[name="password"]', '123456');
    await page.click('input[type="submit"]');

    const logoutButtonLink = await page.$('a[href="javascript:void(0)"]');
    const islogoutButtonLinkVisible = await logoutButtonLink.isVisible();

    expect(islogoutButtonLinkVisible).toBe(true);
});

test('Verify that the "Logout" button redirects correctly', async ({page}) => {
    await page.goto('http://localhost:3000/login');
    await page.fill('input[name="email"]', 'peter@abv.bg');
    await page.fill('input[name="password"]', '123456');
    await page.click('input[type="submit"]');

    const logoutButtonLink = await page.$('a[href="javascript:void(0)"]');
    await logoutButtonLink.click();

    const redirectedURL = page.url();
    expect(redirectedURL).toBe('http://localhost:3000/catalog');
}); 