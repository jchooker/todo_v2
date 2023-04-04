<script setup>
  import ToDoList from './components/ToDoList.vue'
  import {ref} from "vue"
  //import axios from 'axios'

  const showModal = ref(false)
  const newToDo = ref("")
  const toDos = ref([])

  //Date formatting strings for CT: 2019-09-07T15:50-06:00
  //^times have to be fractions of 100, e.g. 30min->00:50

</script>
<template>
  <main>
    <div v-if="showModal" class="overlay">
      <div class="addToDoModal">
        <div class="innerDiv">
          <form @submit.prevent="submitToDoForm" action="" class="form-control shadow-sm row">
              <div class="col">
                  <div class="inputBlock row">
                      <label for="title" class="me-2 col form-check-label">Title<span class="red-text">*</span>: </label>
                      <input id="title" type="text" class="col" v-model="title" required />
                  </div>
                  <div class="inputBlock row">
                      <label for="deadlineDateTime" class="me-2 col form-check-label">Deadline Date<span class="red-text">*</span>: </label>
                      <input id="deadlineDateTime" type="datetime-local" class="col" v-model="deadlineDateTime" required />
                  </div>
                  <div class="inputBlockChk row d-flex justify-content-start">
                      <label for="isComplete" class="me-2 col-7 form-check-label">Is task already complete?</label>
                      <input id="isComplete" type="checkbox" class="col-1 form-check-input" value="" v-model="isComplete" />
                  </div>
                  <div class="inputBlockAlt row d-flex justify-content-start">
                      <label for="note" class="me-2 col form-check-label">Note (Optional):</label>
                      <textarea id="note" class="col" cols="30" rows="3" v-model="note"></textarea>
                  </div>
                  <div class="modalBtnGroup row d-flex justify-content-evenly">

                    <button type="submit" class="btn btn-primary col-5">Submit To Do to list</button>
                    <button type="button" class="btn btn-secondary col-5" @click="showModal = false">Cancel</button>
                  </div>
              </div>
          </form>
      </div>
        </div>
    </div>
      <div class="row d-flex justify-content-evenly">
        <div class="col-4">
          <h1 class="toph1">TO DOs</h1>
        </div>
        <div class="col-8">
          <span class="row d-flex"><h2 class="goldify2 fw-bold">⮦&nbsp;Add&nbsp;</h2>
          </span>
            <button class="newToDoBtn col fw-bolder" type="button" @click="showModal = true">+</button>
        </div>
        </div>
        <div class="mt-4">
          <!-- <ToDoList></ToDoList> -->
        </div>

  </main>
</template>


<style>
@import url('https://fonts.googleapis.com/css2?family=Nunito&display=swap');
  #app {
      font-family: Nunito, Helvetica, Arial, sans-serif;
      -webkit-font-smoothing: antialiased;
      -moz-osx-font-smoothing: grayscale;
      /*text-align: center;*/
      color: tan;
      /*margin-top: 60px;*/
      width: 100%;
  }

  main {
    width: 100%;
    min-height: 50vh;
  }

  body {
      /*margin: 0 auto;*/
      width: 100vw;
      height: 100vh;
      display: block;
      background-color: 	whitesmoke !important;
      /*display: flex;*/
      /*justify-content: center;*/
  }

  .overlay {
    position: absolute;
    width: 100%;
    height: 100%;
    background-color: rgba(0,0,0, 0.6);
    display: flex;
    align-items: center;
    justify-content: center;
    z-index: 10;
  }

  .addToDoModal {
    padding: 1vmax 0 1vmax 0 !important;
  }

  .red-text {
      color: red;
  }

  .innerDiv {
      /*min-width: 40vw;*/
      min-height: 50vh;
  }

    .innerDiv form {
      background-color: linen;
      padding: 1vmax 1vmax 1vmax 0;
    }

  .inputBlock, .inputBlockAlt {
      margin-bottom: 2vh;
  }

  .inputBlockChk {
    width: 100%;
    margin-bottom: 2vh;
  }

  .form-check-input {
    padding: 2vh 0 2vh 0;
  }

  .row-capsule {
    height: 8vh !important;
    width: 50vw;
    color: darkslategray;
  }

  .toph1 {
    color: darkslategray;
  }

  .newToDoBtn {
    border-radius: 0.5vmax;
    border: medium outset gold;
    background-color: darkslategray;
    color: gold;
    padding: 1vmax 2vmax 1vmax 2vmax;
  }

  .goldify {
    color: gold;
  }

  .goldify2 {
    color: #F28C28;
  }

  .trailTxt {
    overflow: hidden;
    white-space: nowrap;
    text-overflow: ellipsis;
  }

</style>
