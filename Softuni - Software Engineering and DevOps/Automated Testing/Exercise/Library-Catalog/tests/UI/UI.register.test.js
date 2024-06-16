const {test, expect} = require('@playwright/test');

// Register Page

test('Sumbit the form with valid values', async({page}) => {
    await page.goto('http://localhost:3000/register');
    await page.fill('#email', 'testUser@abv.bg');
    await page.fill('#password', '123456');
    await page.fill('#repeat-pass', '123456');
    await page.click('input[type="submit"]');

    await page.$('a[href="/catalog"]');

    expect(page.url()).toBe('http://localhost:3000/catalog');
});

test('Sumbit the form with empty values', async({page}) => {
    await page.goto('http://localhost:3000/register');
    await page.click('input[type="submit"]');

    page.on('dialog', async dialog => {
        expect(dialog.type()).toContain('alert');
        expect(dialog.message()).toContain('All fields are required!');
        await dialog.accept();
    });

    await page.$('a[href="/register"]');
    expect(page.url()).toBe('http://localhost:3000/register');
});

test('Sumbit the form with empty email', async({page}) => {
    await page.goto('http://localhost:3000/register');
    await page.fill('#password', '123456');
    await page.fill('#repeat-pass', '123456');
    await page.click('input[type="submit"]');

    page.on('dialog', async dialog => {
        expect(dialog.type()).toContain('alert');
        expect(dialog.message()).toContain('All fields are required!');
        await dialog.accept();
    });

    await page.$('a[href="/register"]');
    expect(page.url()).toBe('http://localhost:3000/register');
});

test('Sumbit the form with empty password', async({page}) => {
    await page.goto('http://localhost:3000/register');
    await page.fill('#email', 'testAccount@abv.bg');
    await page.fill('#repeat-pass', '123456');
    await page.click('input[type="submit"]');

    page.on('dialog', async dialog => {
        expect(dialog.type()).toContain('alert');
        expect(dialog.message()).toContain('All fields are required!');
        await dialog.accept();
    });

    await page.$('a[href="/register"]');
    expect(page.url()).toBe('http://localhost:3000/register');
});

test('Sumbit the form with empty confirm password', async({page}) => {
    await page.goto('http://localhost:3000/register');
    await page.fill('#email', 'testTest@abv.bg');
    await page.fill('#password', '123456');
    await page.click('input[type="submit"]');

    page.on('dialog', async dialog => {
        expect(dialog.type()).toContain('alert');
        expect(dialog.message()).toContain('All fields are required!');
        await dialog.accept();
    });

    await page.$('a[href="/register"]');
    expect(page.url()).toBe('http://localhost:3000/register');
});

test('Sumbit the form with empty different passwords', async({page}) => {
    await page.goto('http://localhost:3000/register');
    await page.fill('#email', 'testProfile@abv.bg');
    await page.fill('#password', '123456');
    await page.fill('#repeat-pass', '654321');
    await page.click('input[type="submit"]');

    page.on('dialog', async dialog => {
        expect(dialog.type()).toContain('alert');
        expect(dialog.message()).toContain('All fields are required!');
        await dialog.accept();
    });

    await page.$('a[href="/register"]');
    expect(page.url()).toBe('http://localhost:3000/register');
});