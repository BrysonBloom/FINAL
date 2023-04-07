<template>
    <div class="CreateVaultModal">
        <div class="modal" tabindex="-1" id="createVaultModal">
            <div class="modal-dialog modal-xl modal-fullscreen-md-down modal-dialog-centered">
                <div class="modal-content" v-if="!mobile">
                    <div>
                        <form class="p-5" @submit.prevent="newVault()">
                            <div class="mb-2">
                                <label class="form-label">Name</label>
                                <input required v-model="editable.name" minlength="3" maxlength="50"
                                    placeholder="Vault Name" type="text" class="form-control">
                            </div>

                            <div class="mb-2">
                                <label class="form-label">description</label>
                                <input v-model="editable.description" minlength="3" maxlength="500"
                                    placeholder="Vault Description (Optional)" type="text" class="form-control">
                            </div>

                            <div class="mb-2">
                                <label class="form-label">Image URL</label>
                                <input required v-model="editable.img" minlength="3" maxlength="500" placeholder="Image URL"
                                    type="text" class="form-control">
                            </div>
                            <div class="mb-2">
                                <label class="form-label">IsPrivate</label>
                                <input v-model="editable.isPrivate" type="checkbox" class="form-check-input">
                            </div>

                            <button data-bs-dismiss="modal" class="btn btn-success" type="submit">Create Vault</button>
                        </form>
                    </div>

                </div>
            </div>
        </div>

    </div>
</template>


<script>
import { computed, ref } from 'vue';
import { AppState } from "../AppState.js";
import { vaultsService } from '../services/VaultsService.js';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';

export default {
    setup() {
        const editable = ref({})

        return {
            editable,

            async newVault() {
                try {
                    const formData = editable.value;
                    await vaultsService.createVault(formData);
                }
                catch (error) {
                    Pop.error(error.message);
                    logger.error(error);
                }
            },

        }
    }
}
</script>


<style lang="scss" scoped></style>