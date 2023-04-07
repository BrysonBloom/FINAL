<template>
    <div class="card" @click="getKeepById(keep.id)" style="background-position: center; background-size: cover;"
        :style="{ backgroundImage: `url(${keep.img})` }">
        <img data-bs-toggle="modal" type="button" data-bs-target="#keepModal" class="img-fluid rounded invis"
            :src="keep.img" alt="">
        <div class="card-body justify-content-between p-0 row">
            <div class="col-9 d-flex align-items-center ps-4">
                <p class="fs-3 shadow-text m-0 text-light">{{ keep.name }}</p>
            </div>
            <div class="col-3 py-2 px-4 text-end">
                <img v-if="!route.params.profileId && route.name != 'Account'" class="rounded-circle" style="height: 40px;"
                    :src="keep.creator.picture" alt="">
                <button v-if="route.name == 'Account'" @click="deleteKeep(keep.id)">DELETE</button>
                <button v-if="user.id == vault.creatorId && vault.id == route.params.vaultId"
                    @click="removeKeepFromVault(keep.vaultKeepId)">Remove</button>
            </div>

        </div>

    </div>
</template>


<script>
import { useRoute } from 'vue-router';
import { Keep } from '../models/Keep';
import { keepsService } from '../services/KeepsService';
import Pop from '../utils/Pop';
import KeepModal from './KeepModal.vue';
import { AppState } from '../AppState';
import { computed } from 'vue';
import { vaultsService } from '../services/VaultsService';

export default {
    props: {
        keep: {
            type: Keep,
            required: true
        }
    },
    setup() {

        let route = useRoute()
        return {
            vault: computed(() => AppState.vault),
            user: computed(() => AppState.account),
            route,
            async getKeepById(id) {
                try {
                    await keepsService.getKeepById(id);
                } catch (error) {
                    Pop.error(error)
                }
            },
            async deleteKeep(id) {
                try {
                    await keepsService.deleteKeep(id);
                } catch (error) {
                    Pop.error(error)
                }
            },
            async removeKeepFromVault(vaultKeepId) {
                try {
                    await vaultsService.removeKeepFromVault(vaultKeepId);
                } catch (error) {
                    Pop.error(error)
                }
            }
        }
    },
    components: { KeepModal }
}
</script>


<style lang="scss" scoped>
.shadow-text {
    text-shadow: 1px .5px 2px black;
}

.invis {
    opacity: 0%;
}
</style>