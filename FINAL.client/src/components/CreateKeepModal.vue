<template>
    <div class="CreateKeepModal">
        <div class="modal" tabindex="-1" id="createKeepModal">
            <div class="modal-dialog modal-xl modal-fullscreen-md-down modal-dialog-centered">
                <div class="modal-content" v-if="!mobile">
                    <div>
                        <form class="p-5" @submit.prevent="newKeep()">
                            <div class="mb-2">
                                <label class="form-label">Name</label>
                                <input required v-model="editable.name" minlength="3" maxlength="50" placeholder="Keep Name"
                                    type="text" class="form-control">
                            </div>

                            <div class="mb-2">
                                <label class="form-label">description</label>
                                <input v-model="editable.description" minlength="3" maxlength="500"
                                    placeholder="Keep Description (Optional)" type="text" class="form-control">
                            </div>

                            <div class="mb-2">
                                <label class="form-label">Image URL</label>
                                <input required v-model="editable.img" minlength="3" maxlength="500" placeholder="Image URL"
                                    type="text" class="form-control">
                            </div>

                            <button data-bs-dismiss="modal" class="btn btn-success" type="submit">Create Keep</button>
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
import { keepsService } from '../services/KeepsService.js';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';

export default {
    setup() {
        const editable = ref({})

        return {
            editable,

            async newKeep() {
                try {
                    const formData = editable.value;
                    await keepsService.createKeep(formData);
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