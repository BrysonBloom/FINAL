<template>
    <div class="EditAccountModal">
        <div class="modal" tabindex="-1" id="editAccountModal">
            <div class="modal-dialog modal-xl modal-fullscreen-md-down modal-dialog-centered">
                <div class="modal-content" v-if="!mobile">
                    <div>
                        <form class="p-5" @submit.prevent="EditAccount()">
                            <div class="mb-2">
                                <label class="form-label">Name</label>
                                <input required v-model="editable.name" minlength="3" maxlength="50" placeholder="Keep Name"
                                    type="text" class="form-control">
                            </div>

                            <div class="mb-2">
                                <label class="form-label">Image</label>
                                <input v-model="editable.picture" minlength="3" maxlength="500" placeholder="Profile Img"
                                    type="text" class="form-control">
                            </div>

                            <div class="mb-2">
                                <label class="form-label">Cover Image</label>
                                <input required v-model="editable.coverImg" minlength="3" maxlength="500"
                                    placeholder="Image URL" type="text" class="form-control">
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
import { accountService } from '../services/AccountService.js';

export default {
    setup() {
        const editable = ref({})

        return {
            editable,

            async EditAccount() {
                try {
                    const formData = editable.value;
                    await accountService.editAccount(formData);
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