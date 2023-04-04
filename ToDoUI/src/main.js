import { createApp } from 'vue'
import App from './App.vue'
import $ from 'jquery'
import 'bootstrap/dist/css/bootstrap.min.css'
import 'bootstrap'
import { library } from '@fortawesome/fontawesome-svg-core'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import { faUserSecret } from '@fortawesome/free-solid-svg-icons'

library.add(faUserSecret)

import './assets/main.css'

createApp(App)
.component('font-awesome-icon', FontAwesomeIcon)
.mount('#app')

var baseURL = "http://localhost:5096"

function GetToDos() {
    var settings = {
        "url": baseURL,
        "method": "GET"
    }
    return $.ajax(settings);
}
function GetToDo(id) {
    var settings = {
        "url": baseURL + '?id=' + id,
        "method": "GET"
    }
    return $.ajax(settings);
}
function DeleteToDo(id) {
    var settings = {
        "url": baseURL + '?id=' + id,
        "method": "DELETE"
    }
    return $.ajax(settings);
}

///*****NEED TO ADD UPDATE/PATCH AND CREATE! How to pass a full todo? */