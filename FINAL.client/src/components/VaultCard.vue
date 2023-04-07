<template>
    <router-link :to="{ name: 'Vault', params: { vaultId: vault.id } }">
        <div class="mt-2">
            <div class="card" style="background-position: center; background-size: cover;"
                :style="{ backgroundImage: `url(${vault.img})` }">

                <div class="card-body text-light justify-content-between p-0 row">
                    <div class="col-9 d-flex align-items-center ps-4">
                        <p class="fs-3 shadow-text m-0">{{ vault.name }}</p>
                    </div>

                </div>

            </div>

        </div>
    </router-link>
</template>


<script>
import { computed } from 'vue';
import { AppState } from '../AppState';
import { Vault } from '../models/Vault';
export default {
    props: {
        vault: {
            type: Vault,
            required: true
        }
    },
    setup() {
        return {

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