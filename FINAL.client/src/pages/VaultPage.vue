<template>
    <div class="component">
        <div class=" container-fluid" v-if="keeps[0]">
            <div class="grid">
                <div data-bs-toggle="modal" type="button" data-bs-target="#keepModal" v-for="k in keeps">
                    <KeepCard :keep="k" />
                </div>
            </div>
        </div>
        <KeepModal />

    </div>
</template>


<script>
import { useRoute } from 'vue-router';
import KeepCard from '../components/KeepCard.vue';
import KeepModal from '../components/KeepModal.vue';
import { vaultsService } from '../services/VaultsService'
import { onMounted, computed } from 'vue';
import Pop from '../utils/Pop';
import { AppState } from '../AppState';
export default {
    setup() {
        const route = useRoute()

        async function getKeepsInVault() {
            try {
                const vaultId = route.params.vaultId
                await vaultsService.getKeepsInVault(vaultId)
            } catch (error) {
                Pop.error(error)
            }
        }
        onMounted(() => {
            getKeepsInVault()
        })
        return {
            keeps: computed(() => AppState.keeps),
            user: computed(() => AppState.account),
            vault: computed(() => AppState.vault),
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