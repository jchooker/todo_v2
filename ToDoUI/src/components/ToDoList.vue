<template>
  <!--<pre>{{ data }}</pre>-->
  <div class="row-capsule d-flex justify-content-between mt-10">
    <p>CLICK TO EXPAND</p>
    <p>(DELETE)</p>
  </div>
  <div v-html="toDo"></div>
</template>

<script>

  //import { ref } from 'vue'

  //export default {
  //    name: 'ToDoList',
  //    async setup() {
  //        const data = ref(null)

  //        await new Promise((r) => setTimeout(r, 2000))

  //        try {
  //            const res = await axios.get("http://localhost:5196/api/todo");
  //            data.value = await res.json()
  //        } catch (e) {
  //            console.error(e);
  //        }

  //        return { data };
  //    }
  //}
  // At instance level
  // const instance = axios.create({ //<--04/03: figure out how to set this up to
      //avoid problems with SSL! "You can configure axios to 
      //use a custom agent and set rejectUnauthorized to false for that agent: "
  //    httpsAgent: new https.Agent({
  //        rejectUnauthorized: false
  //    })
  //});
  //instance.get('https://localhost:7024/api/todo');

  // At request level
  //const agent = new https.Agent({
  //    rejectUnauthorized: false
  //});
  //axios.get('https://localhost:7024/api/todo', { httpsAgent: agent });

</script>
