function solve() {
    let nextStop = `depot`;
    function depart() {
        const stop = document.getElementsByClassName('info')[0].textContent;
        let initUrl = 'http://localhost:3030/jsonstore/bus/schedule/'+nextStop;
        const response = fetch(initUrl)
        .then((res)=>{
            res.json()
            .then((json)=>{
                const name = `Next stop `+json.name;
                nextStop = json.next;
                document.getElementsByClassName('info')[0].textContent=name;
                document.getElementById('depart').disabled=true;
                document.getElementById('arrive').disabled=false;
            })
            .catch(()=>{
                document.getElementsByClassName('info')[0].textContent='Error';
            });
        })
        .catch(()=>{
            document.getElementsByClassName('info')[0].textContent='Error';
        });
    }

    async function arrive() {
        document.getElementById('depart').disabled=false;
        document.getElementById('arrive').disabled=true;
        document.getElementsByClassName('info')[0].textContent=`Arriving at ${
        document.getElementsByClassName('info')[0].textContent.split(' ').slice(2,
        document.getElementsByClassName('info')[0].textContent.length).join(' ')
        }`;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();