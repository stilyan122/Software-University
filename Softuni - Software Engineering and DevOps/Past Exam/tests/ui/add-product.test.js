const { test, expect } = require('@playwright/test');

test('Check add products page', async ({ page }) => {
    await page.goto('http://localhost:8090/add-product');
    const form = await page.$('form');
    expect(form).toBeTruthy();
  });
  