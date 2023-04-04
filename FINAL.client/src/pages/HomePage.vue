<template>
  <div class="container" v-if="keeps[0]">
    <button class=" row bricks" data-bs-toggle="modal" type="button" data-bs-target="#keepModal" v-for="k in keeps">
      <KeepCard :keep="k" />
    </button>
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

.bricks {
  display: flex;

  flex-flow: column wrap;
  max-height: 1000px;
  width: 25%;

  &>div {
    margin-top: $gap;
    display: inline-block;
  }
}
</style>
