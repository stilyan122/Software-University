function attachEvents() {
  const URL = 'http://localhost:3030/jsonstore/collections/books';
  const form = document.getElementById('form');

  const submit = form.getElementsByTagName('button')[0];
  const load = document.getElementById('loadBooks');

  const body = document.getElementsByTagName('tbody')[0];

  submit.addEventListener('click',function(){
    createBook();
  });

  load.addEventListener('click',function(){
    loadBooks();
  })

  function loadBooks(){
    fetch(URL)
    .then((res)=>{
      res.json()
      .then((json)=>{
        body.innerHTML='';
        for (const entry of Object.entries(json)) {
          const row = document.createElement('tr');
          const col1 = document.createElement('td');
          const col2 = document.createElement('td');
          const col3 = document.createElement('td');
        

          const editBtn = document.createElement('button');
          editBtn.textContent='Edit';

          editBtn.addEventListener('click',function(){
            updateBook(entry[1]._id,entry[1].title,entry[1].author);
          });

          const deleteBtn = document.createElement('button');
          deleteBtn.textContent='Delete'; 

          deleteBtn.addEventListener('click',function(){
            deleteBook(entry[1]._id,row);
          })

          col1.textContent=entry[1].title;
          col2.textContent=entry[1].author;
          col3.appendChild(editBtn);
          col3.appendChild(deleteBtn);

          row.appendChild(col1);
          row.appendChild(col2);
          row.appendChild(col3);
          body.appendChild(row);
        }
      })
    })
  }
  // ** not included in task!
  function getBook(id){
    fetch(URL+`\\${id}`)
    .then((res)=>{
      res.json()
        .then((json)=>{
          console.log(json);
      });
    });
  }
  // ** 

  function createBook(){
    const titleField = form.getElementsByTagName('input')[0].value;
    const authorField = form.getElementsByTagName('input')[1].value;
    
     if(titleField!==''&&authorField!==''){
      const bookObj = {
        author:authorField,
        title:titleField
      }
      fetch(URL,{
        method:'POST',
        headers:{'Content-Type':'application/json'},
        body:JSON.stringify(bookObj)
      });
      form.getElementsByTagName('input')[0].value='';
      form.getElementsByTagName('input')[1].value='';
     }
  }

  function updateBook(id,title,author){
    form.getElementsByTagName('h3')[0].textContent='Edit FORM';
    form.getElementsByTagName('input')[0].value=title;
    form.getElementsByTagName('input')[1].value=author;
    submit.textContent='Save';
    submit.addEventListener('click',function(){
      const updateURL = URL+'\\'+id;
      const bookObj={
        author:title,
        title:author,
      }
      fetch(updateURL,
        {
          method:'PUT',
          headers:{'Content-Type':'application/json'},
          body:JSON.stringify(bookObj)
        });
      submit.textContent='Submit';
      form.getElementsByTagName('input')[0].value='';
      form.getElementsByTagName('input')[1].value='';
      form.getElementsByTagName('h3')[0].textContent='FORM';
    })
  }

  function deleteBook(id,row){
    const deleteURL = URL+'\\'+id;
    fetch(deleteURL,{
      method:'DELETE'
    }).then(()=>{
      body.removeChild(row);
    });
  }


}

attachEvents();