<template>
    <router-link :to="{ name: 'Vault', params: { vaultId: vault.id } }" @click="setVault(vault)">
        <div class="mt-2">
            <div class="card" style="background-position: center; background-size: cover;"
                :style="{ backgroundImage: `url(${vault.img})` }">

                <div class="card-body text-light align-items-end justify-content-between p-0 row">
                    <div class="col-12 d-flex align-items-center ps-4">
                        <p class="fs-3 shadow-text m-0">{{ vault.name }}</p>
                        <button v-if="vault.isPrivate" class="btn btn-sm btn-warning">PRIVATE</button>
                    </div>
                    <button v-if="userId == vault.creatorId" class="btn btn-danger" style="width: min-content;"
                        @click="deleteVault(vault.id)">DELETE</button>

                </div>

            </div>

        </div>
    </router-link>
</template>


<script>
import { computed } from 'vue';
import { AppState } from '../AppState';
import { Vault } from '../models/Vault';
import Pop from '../utils/Pop';
import { vaultsService } from '../services/VaultsService';
export default {
    props: {
        vault: {
            type: Vault,
            required: true
        }
    },
    setup() {
        return {
            userId: computed(() => AppState.account.id),

            async deleteVault(id) {
                try {
                    vaultsService.deleteVault(id);

                } catch (error) {
                    Pop.error(error)
                }
            },
            async setVault(vault) {
                AppState.vault = vault;
            }
        }
    }
}
</script>


<style lang="scss" scoped>
.card {
    height: 15vh;
}

.shadow-text {
    text-shadow: 1px .5px 2px black;
}
</style>