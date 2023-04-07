<template>
  <div class="container">

    <div class="row" v-if="vaults[0]">
      <div class="col-4" v-for="v in vaults">
        <VaultCard :vault="v" />
      </div>
    </div>
    <div class="grid" v-if="keeps[0]">
      <div v-for="k in keeps">
        <KeepCard :keep="k" />
      </div>
    </div>
  </div>
  <KeepModal />
</template>


<script>
import { useRoute } from 'vue-router';
import { onMounted, computed, watchEffect } from 'vue';
import KeepCard from '../components/KeepCard.vue';
import KeepModal from '../components/KeepModal.vue';
import VaultCard from '../components/VaultCard.vue';
import { vaultsService } from '../services/VaultsService';
import Pop from '../utils/Pop';
import { AppState } from '../AppState';
export default {
  setup() {

    watchEffect(() => {
      if (AppState.account.id) { getKeepsByProfile() }

    })

    async function getKeepsByProfile() {
      try {
        const userId = AppState.account.id
        await vaultsService.getKeepsByProfile(userId)
      } catch (error) {
        Pop.error(error)
      }
    }
    return {
      keeps: computed(() => AppState.keeps),
      vaults: computed(() => AppState.myVaults),


    }
  }
}
</script>


<style lang="scss" scoped>
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
</style>
