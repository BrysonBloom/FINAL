<template>
    <div class="KeepModal">
        <div class="modal" tabindex="-1" id="keepModal">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">

                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body" v-if="keep.id">
                        <div class="row">
                            <div class="col-6">
                                <img class="img-fluid" :src="keep.img" alt="">
                            </div>
                            <div class="col-6">
                                <div class="row">
                                    <div class="col-12"><i class="mdi mdi-eye">{{ keep.views }}</i></div>
                                </div>
                                <div class="row">
                                    <div class="col-12">
                                        <h1>{{ keep.name }}</h1>
                                        <p>{{ keep.description }}</p>
                                    </div>
                                </div>
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
import { computed } from "vue";
import Pop from "../utils/Pop.js";
import { Keep } from "../models/Keep.js";

export default {
    props: {
        keep: {
            type: Keep,
            required: true
        }
    },
    setup() {
        return {
            account: computed(() => AppState.account),
            keep: computed(() => AppState.keep)
        }
    }
}
</script>


<style lang="scss" scoped></style>