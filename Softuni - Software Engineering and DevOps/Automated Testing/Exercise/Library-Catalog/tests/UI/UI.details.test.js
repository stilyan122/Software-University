const {test, expect} = require('@playwright/test');

// "Details" Page

test('Verify that logged-in user sees details button and button works correctly', async ({page}) => {
    await page.goto('http://localhost:3000/login');
    
    await page.fill('input[name="email"]', 'peter@abv.bg');
    await page.fill('input[name="password"]', '123456');

    await Promise.all([
        page.click('input[type="submit"]'),
        page.waitForURL('http://localhost:3000/catalog')
    ]);

    await page.click('a[href="/catalog"]');

    await page.waitForSelector('.otherBooks');

    await page.click('.otherBooks a.button');

    await page.waitForSelector('.book-information');

    const detailsPageTitle = await page.textContent('.book-information h3');
    expect(detailsPageTitle).toBe('Test Book');
});

test('Verify that guest user sees details button and button works correctly', async ({page}) => {
    await page.goto('http://localhost:3000');

    await page.click('a[href="/catalog"]');

    await page.waitForSelector('.otherBooks');

    await page.click('.otherBooks a.button');

    await page.waitForSelector('.book-information');

    const detailsPageTitle = await page.textContent('.book-information h3');
    expect(detailsPageTitle).toBe('Test Book');
});

test('Verify that all info is displayed correctly', async ({page}) => {
    await page.goto('http://localhost:3000');

    await page.click('a[href="/catalog"]');

    await page.waitForSelector('.otherBooks');

    await page.click('.otherBooks a.button');

    await page.waitForSelector('.book-information');

    const detailsPageTitle = await page.textContent('.book-information h3');
    const detailsPageDescription = await page.textContent('.book-description p');
    const detailsPageType = await page.textContent('.type');

    expect(detailsPageTitle).toBe('Test Book');
    expect(detailsPageDescription).toBe('This is a test book description');
    expect(detailsPageType).toContain('Fiction');
});

test('Verify if edit and delete buttons are visible for creator', async ({page}) => {
    await page.goto('http://localhost:3000/login');
    
    await page.fill('input[name="email"]', 'john@abv.bg');
    await page.fill('input[name="password"]', '123456');

    await Promise.all([
        page.click('input[type="submit"]'),
        page.waitForURL('http://localhost:3000/catalog')
    ]);

    await page.click('a[href="/catalog"]');

    await page.waitForSelector('.otherBooks');

    await page.click('.otherBooks a.button');

    await page.waitForSelector('.actions');

    const div = await page.$('.actions');

    const divButtons = await div.$$('.button');

    const editButton = await divButtons[0].textContent();
    const deleteButton = await divButtons[1].textContent();

    expect(editButton).toBe('Edit');
    expect(deleteButton).toBe('Delete');
});

test('Verify if edit and delete buttons are not visible for non-creator', async ({page}) => {
    await page.goto('http://localhost:3000/login');
    
    await page.fill('input[name="email"]', 'peter@abv.bg');
    await page.fill('input[name="password"]', '123456');

    await Promise.all([
        page.click('input[type="submit"]'),
        page.waitForURL('http://localhost:3000/catalog')
    ]);

    await page.click('a[href="/catalog"]');

    await page.waitForSelector('.otherBooks');

    await page.click('.otherBooks a.button');

    await page.waitForSelector('.actions');

    const div = await page.$('.actions');

    const divButtons = await div.$$('.button');

    // Only "Like" button is shown
    expect(divButtons.length).toBe(1);
});

test('Verify if like button is not visible for creator', async ({page}) => {
    await page.goto('http://localhost:3000/login');
    
    await page.fill('input[name="email"]', 'john@abv.bg');
    await page.fill('input[name="password"]', '123456');

    await Promise.all([
        page.click('input[type="submit"]'),
        page.waitForURL('http://localhost:3000/catalog')
    ]);

    await page.click('a[href="/catalog"]');

    await page.waitForSelector('.otherBooks');

    await page.click('.otherBooks a.button');

    await page.waitForSelector('.actions');

    const div = await page.$('.actions');

    const divButtons = await div.$$('.button');

    // Only "Edit" and "Delete" buttons are shown
    expect(divButtons.length).toBe(2);
});

test('Verify if like button is visible for non-creator', async ({page}) => {
    await page.goto('http://localhost:3000/login');
    
    await page.fill('input[name="email"]', 'peter@abv.bg');
    await page.fill('input[name="password"]', '123456');

    await Promise.all([
        page.click('input[type="submit"]'),
        page.waitForURL('http://localhost:3000/catalog')
    ]);

    await page.click('a[href="/catalog"]');

    await page.waitForSelector('.otherBooks');

    await page.click('.otherBooks a.button');

    await page.waitForSelector('.actions');

    const div = await page.$('.actions');

    const divButtons = await div.$$('.button');

    // Only "Like" button is shown
    expect(divButtons.length).toBe(1);
});