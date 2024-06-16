const {test, expect} = require('@playwright/test');

// "Add Book" Page

test('Submit the form with correct data', async ({page}) => {
    await page.goto('http://localhost:3000/login');
    
    await page.fill('input[name="email"]', 'peter@abv.bg');
    await page.fill('input[name="password"]', '123456');

    await Promise.all([
        page.click('input[type="submit"]'),
        page.waitForURL('http://localhost:3000/catalog')
    ]);

    await page.click('a[href="/create"]');

    await page.waitForSelector('#create-form');

    await page.fill('#title', 'Test Book');
    await page.fill('#description', 'This is a test book description');
    await page.fill('#image', 'https://example.com/book-image.jpg');
    await page.selectOption('#type', 'Fiction');

    await page.click('#create-form input[type="submit"]');

    await page.waitForURL('http://localhost:3000/catalog');

    expect(page.url()).toBe('http://localhost:3000/catalog');
});

test('Submit the form with empty title field', async ({page}) => {
    await page.goto('http://localhost:3000/login');
    
    await page.fill('input[name="email"]', 'peter@abv.bg');
    await page.fill('input[name="password"]', '123456');

    await Promise.all([
        page.click('input[type="submit"]'),
        page.waitForURL('http://localhost:3000/catalog')
    ]);

    await page.click('a[href="/create"]');

    await page.waitForSelector('#create-form');

    await page.fill('#description', 'This is a test book description');
    await page.fill('#image', 'https://example.com/book-image.jpg');
    await page.selectOption('#type', 'Fiction');

    await page.click('#create-form input[type="submit"]');

    page.on('dialog', async dialog =>{
        expect(dialog.type()).toContain('alert');   
        expect(dialog.message()).toContain('All fields are required!');  
        await dialog.accept(); 
    });

    await page.$('a[href="/create"]');

    expect(page.url()).toBe('http://localhost:3000/create');
});

test('Submit the form with empty description field', async ({page}) => {
    await page.goto('http://localhost:3000/login');
    
    await page.fill('input[name="email"]', 'peter@abv.bg');
    await page.fill('input[name="password"]', '123456');

    await Promise.all([
        page.click('input[type="submit"]'),
        page.waitForURL('http://localhost:3000/catalog')
    ]);

    await page.click('a[href="/create"]');

    await page.waitForSelector('#create-form');

    await page.fill('#title', 'Test Book');
    await page.fill('#image', 'https://example.com/book-image.jpg');
    await page.selectOption('#type', 'Fiction');

    await page.click('#create-form input[type="submit"]');

    page.on('dialog', async dialog =>{
        expect(dialog.type()).toContain('alert');   
        expect(dialog.message()).toContain('All fields are required!');  
        await dialog.accept(); 
    });

    await page.$('a[href="/create"]');

    expect(page.url()).toBe('http://localhost:3000/create');
});

test('Submit the form with empty image URL field', async ({page}) => {
    await page.goto('http://localhost:3000/login');
    
    await page.fill('input[name="email"]', 'peter@abv.bg');
    await page.fill('input[name="password"]', '123456');

    await Promise.all([
        page.click('input[type="submit"]'),
        page.waitForURL('http://localhost:3000/catalog')
    ]);

    await page.click('a[href="/create"]');

    await page.waitForSelector('#create-form');

    await page.fill('#title', 'Test Book');
    await page.fill('#description', 'This is a test book description');
    await page.selectOption('#type', 'Fiction');

    await page.click('#create-form input[type="submit"]');

    page.on('dialog', async dialog =>{
        expect(dialog.type()).toContain('alert');   
        expect(dialog.message()).toContain('All fields are required!');  
        await dialog.accept(); 
    });

    await page.$('a[href="/create"]');

    expect(page.url()).toBe('http://localhost:3000/create');
});