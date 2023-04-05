<template>
  <div class=" container-fluid" v-if="keeps[0]">
    <div class="grid">
      <div data-bs-toggle="modal" type="button" data-bs-target="#keepModal" v-for="k in keeps">
        <KeepCard :keep="k" />
      </div>
    </div>
  </div>
  <KeepModal />
</template>

<script>
import Pop from '../utils/Pop';
import { keepsService } from '../services/KeepsService.js';
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState';
import KeepCard from '../components/KeepCard.vue';
import KeepModal from '../components/KeepModal.vue';


export default {
  setup() {
    async function getKeeps() {
      try {
        await keepsService.getKeeps();
      }
      catch (error) {
        Pop.error(error);
      }
    }
    onMounted(() => {
      getKeeps();
    });
    return {
      keeps: computed(() => AppState.keeps)
    };
  },
  components: { KeepCard, KeepModal }
}
</script>

<style scoped lang="scss">
$gap: .5em;

.grid {
  // display: grid;
  // grid-gap: 10px;
  // grid-template-columns: repeat(auto-fill, minmax(250px, 1fr));
  // grid-auto-rows: 20px;
  // height: auto;

  // display: flex;
  // flex-flow: column wrap;
  // max-height: 1000px;
  // width: 25%;

  columns: 300px;
  column-gap: $gap;

  &>div {
    margin-top: $gap;
    margin-left: $gap;
    display: inline-block;
  }
}

// .grid-item {
//   width: 200px;
// }
</style>
