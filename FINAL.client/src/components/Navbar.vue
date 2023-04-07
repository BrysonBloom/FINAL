<template>
  <nav class="navbar navbar-expand-lg navbar-dark bg-dark px-3">
    <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">
      <button class="btn btn-primary">
        HOME

      </button>
    </router-link>
    <button data-bs-toggle="modal" type="button" data-bs-target="#createKeepModal">
      create Keep
    </button>
    <button data-bs-toggle="modal" type="button" data-bs-target="#createVaultModal">
      create Vault
    </button>
    <button data-bs-toggle="modal" type="button" data-bs-target="#editAccountModal">
      Edit Account
    </button>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText"
      aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarText">
      <ul class="navbar-nav me-auto">
        <li>
          <router-link :to="{ name: 'Account' }" class="btn text-success lighten-30 selectable text-uppercase">
            Account
          </router-link>
        </li>
      </ul>
      <!-- LOGIN COMPONENT HERE -->
      <Login />
    </div>
  </nav>
  <CreateKeepModal />
  <CreateVaultModal />
  <EditAccountModal />
</template>

<script>
import Login from './Login.vue'
import CreateKeepModal from './CreateKeepModal.vue';
import CreateVaultModal from './CreateVaultModal.vue';
import EditAccountModal from './EditAccountModal.vue';
export default {
  setup() {
    return {}
  },
  components: { Login, CreateKeepModal, CreateVaultModal, EditAccountModal }
}
</script>

<style scoped>
a:hover {
  text-decoration: none;
}

.nav-link {
  text-transform: uppercase;
}

.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}

@media screen and (min-width: 768px) {
  nav {
    height: 64px;
  }
}
</style>
