<template>
    <div class="KeepModal">
        <div class="modal" tabindex="-1" id="keepModal">
            <div class="modal-dialog modal-xl modal-fullscreen-md-down modal-dialog-centered">
                <div class="modal-content" v-if="keep.id && !mobile">
                    <div class="row justify-content-between d-flex">
                        <div class="col-6">
                            <img class="img-fluid rounded-start" :src="keep.img" alt="">
                        </div>
                        <div class="col-6 ">
                            <div class="row ">
                                <div class="col-12"><i class="mdi mdi-eye">{{ keep.views }}</i><i class="mdi mdi-floppy">{{
                                    keep.kept }}</i>
                                </div>
                            </div>
                            <div class="row align-items-center h-85">
                                <div class="col-10 m-auto ">
                                    <h1 class="text-center">{{ keep.name }}</h1>
                                    <p>{{ keep.description }}</p>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-9">
                                    <form @submit.prevent="addKeepToVault(keep.id)">
                                        <select class="border select w-25" v-model="editable.vault"
                                            aria-label="add to vault">
                                            <option selected>Choose vault</option>
                                            <option v-for="v in vaults" :value="v.id">{{ v.name }}</option>
                                        </select>
                                        <button class="btn btn-primary">Add</button>
                                    </form>
                                </div>
                                <div class="col-3"><router-link
                                        :to="{ name: 'Profile', params: { profileId: keep.creator.id } }">
                                        <div type="button" data-bs-dismiss="modal" aria-label="Close">
                                            <div><img :src="keep.creator.picture" class="img-fluid rounded-circle"
                                                    style="height: 50px;" alt=""></div>
                                        </div>

                                    </router-link></div>



                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>

    </div>
</template>


<script>
import { AppState } from "../AppState.js";
import { computed, ref } from "vue";
import Pop from "../utils/Pop.js";
import { Keep } from "../models/Keep.js";
import { vaultsService } from "../services/VaultsService";
import { logger } from "../utils/Logger";

export default {
    props: {
        keep: {
            type: Keep,
            required: true
        }
    },
    setup() {
        const editable = ref({})
        return {
            editable,
            account: computed(() => AppState.account),
            keep: computed(() => AppState.keep),
            mobile: computed(() => AppState.isMobile),
            vaults: computed(() => AppState.myVaults),

            async addKeepToVault(keepId) {
                try {
                    let vault = editable.value;
                    logger.log(vault.vault)
                    await vaultsService.addKeepToVault(vault.vault, keepId);
                } catch (error) {
                    Pop.error(error);
                }
            }

        }
    }
}
</script>


<style lang="scss" scoped>
.select {
    border-bottom: 3px solid black;
}

.h-85 {
    height: 90%;
}
</style>