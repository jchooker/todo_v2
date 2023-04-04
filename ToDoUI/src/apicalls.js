import axios, {isCancel, AxiosError} from 'axios';
import { createApp } from 'vue'
import App from './App.vue'

import './main.js'

const API_URL = "http://localhost:5096/api/"

const toDo={template: `

<div v-for="_td in toDos" class="row-capsule row" :id="'toDoNum'+_td.Id">ToDos
    <div class="col-8">
        <div class="row d-flex justify-content-start">
            <p class="col">{{_td.Title}}</p>
        </div>
        <div class="row d-flex justify-content-between">
            <p class="col">{{_td.DateCreated}}</p>
            <p class="col trailTxt">{{_td.Note}}</p>
        </div>
    </div>
    <div class="col-3">
        <div class="row">
            <div class="col">
                <a :id="'delToDo'+_td.Id" href="#">Delete</a>
                <a :id="'editToDo'+_td.Id" href="#">Edit</a>
            </div>
        </div>
    </div>
</div>
`, 

data(){
    return{
        toDos:[]
    }
},
methods:{
    refreshData(){
        axios.get(API_URL+"todo")
        .then((response)=>{
            this.toDos=response.data
        })
        .catch(error => {
            console.log(error + 'AXIOS METHOD ERROR')
        })
    }
},
mounted:function(){
    this.refreshData();
}
}

