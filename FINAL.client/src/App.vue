<template>
  <header>
    <Navbar />
  </header>
  <main>
    <router-view />
  </main>
  <footer class="bg-dark text-light">
    Made with 💖 by CodeWorks
  </footer>
</template>

<script>
import { computed, onMounted } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'
import KeepModal from './components/KeepModal.vue'
import CreateKeepModal from './components/CreateKeepModal.vue'
import { logger } from './utils/Logger'
import { vaultsService } from './services/VaultsService'


export default {
  setup() {

    let minWidth = window.matchMedia("(max-width: 415px)")
    onMounted(() => {
      if (minWidth.matches) {
        AppState.isMobile = true
        logger.log(AppState.isMobile)
      }
      if (AppState.account) {
        vaultsService.getMyVaults
      }
    })


    // while (minWidth.matches) {
    //   AppState.isMobile = true
    // }
    // while (!minWidth.matches) {
    //   AppState.isMobile = false
    // }
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar, KeepModal, CreateKeepModal }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root {
  --main-height: calc(100vh - 32px - 64px);
}


footer {
  display: grid;
  place-content: center;
  height: 32px;
}
</style>
