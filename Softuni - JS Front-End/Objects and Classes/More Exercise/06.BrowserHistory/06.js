function browsing(obj,strings) {
    const browser = obj['Browser Name'];
    let opened = obj['Open Tabs'];
    let closed = obj['Recently Closed'];
    let logsBrowser = obj['Browser Logs'];
    let logs = strings;
    let commandLogs = logsBrowser;
    for (const log of logs) {
        const command = log.split(' ')[0];
        const tab = log.split(' ').slice(1,log.length).join(' ');
        if (command==='Open') {
            opened.push(tab);
            commandLogs.push(log);
        }
        else if(command==='Close' && opened.includes(tab)){
            const index = opened.indexOf(tab);
            opened.splice(index,1);
            closed.push(tab);
            commandLogs.push(log);
        }
        else if(log==='Clear History and Cache'){
            commandLogs = [];
            opened = [];
            closed = [];
        }
    }
    console.log(browser);
    console.log(`Open Tabs: ${opened.join(', ')}`);
    console.log(`Recently Closed: ${closed.join(', ')}`);
    console.log(`Browser Logs: ${commandLogs.join(', ')}`);
}