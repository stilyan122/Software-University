const {test, expect} = require('@playwright/test');

// "All Books" Page

test('Verify that all books are displayed', async ({page}) => {
    await page.goto('http://localhost:3000/login');
    
    await page.fill('input[name="email"]', 'peter@abv.bg');
    await page.fill('input[name="password"]', '123456');

    await Promise.all([
        page.click('input[type="submit"]'),
        page.waitForURL('http://localhost:3000/catalog')
    ]);

    await page.waitForSelector('.dashboard');

    const bookElements = await page.$$('.other-books-list li');

    expect(bookElements.length).toBeGreaterThan(0);
});

test('Verify that no books are displayed', async ({page}) => {
    await page.goto('http://localhost:3000/login');
    
    await page.fill('input[name="email"]', 'john@abv.bg');
    await page.fill('input[name="password"]', '123456');

    await Promise.all([
        page.click('input[type="submit"]'),
        page.waitForURL('http://localhost:3000/catalog')
    ]);

    await page.waitForSelector('.dashboard');

    const bookElements = await page.$$('.other-books-list li');
    const noBooksMessage = await page.textContent('.no-books');

    expect(bookElements.length).toBe(0);
    expect(noBooksMessage).toBe('No books in database!');
});