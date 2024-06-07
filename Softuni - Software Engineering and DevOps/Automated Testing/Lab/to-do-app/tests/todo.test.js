import { test, expect } from '@playwright/test';

// Verify if a user can add a task
test('User can add task', async({ page }) => {
    await page.goto('http://localhost:5500');
    await page.fill('#task-input', 'Test Task');
    await page.click('#add-task');
    
    const taskTest = await page.textContent('.task');
    expect(taskTest).toContain('Test Task');
});

// Verify if a user can delete a task
test('User can delete task', async({ page }) => {
    await page.goto('http://localhost:5500');
    await page.fill('#task-input', 'Test Task');
    await page.click('#add-task');
    await page.click('.task .delete-task');
    
    const tasks = await page.$$eval('.task',
        tasks => tasks.map(task => task.textContent));

    expect(tasks).not.toContain('Test Task');
});

// Verify if a user can mark a task as complete
test('User can mark a task as complete', async({ page }) => {
    await page.goto('http://localhost:5500');
    await page.fill('#task-input', 'Test Task');
    await page.click('#add-task');
    await page.click('.task .task-complete');
    
    const completedTask = await page.$('.task.completed');

    expect(completedTask).not.toBeNull();
});

// Verify if a user can filter tasks
test('User can filter tasks', async({ page }) => {
    await page.goto('http://localhost:5500');
    await page.fill('#task-input', 'Test Task');
    await page.click('#add-task');
    await page.click('.task .task-complete');
    await page.selectOption('#filter', 'Completed');

    const incompletedTask = await page.$('.task:not(.completed)');

    expect(incompletedTask).toBeNull();
});