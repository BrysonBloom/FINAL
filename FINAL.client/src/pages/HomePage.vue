<template>
  <div class="container" v-if="keeps[0]">
    <div class=" row bricks" v-for="k in keeps">
      <KeepCard :keep="k" />
    </div>
  </div>
</template>

<script>
import Pop from '../utils/Pop';
import { keepsService } from '../services/KeepsService.js';
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState';
import KeepCard from '../components/KeepCard.vue';


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
  components: { KeepCard }
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
