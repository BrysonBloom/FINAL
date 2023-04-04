<template>
    <button class="card" @click="getKeepById(keep.id)">
        <img class="img-fluid" :src="keep.img" alt="">
        <div class="card-body text-center">
            {{ keep.name }}
        </div>

    </button>
</template>


<script>
import { Keep } from '../models/Keep';
import { keepsService } from '../services/KeepsService';
import Pop from '../utils/Pop';
import KeepModal from './KeepModal.vue';

export default {
    props: {
        keep: {
            type: Keep,
            required: true
        }
    },
    setup() {


        return {
            async getKeepById(id) {
                try {
                    await keepsService.getKeepById(id);
                } catch (error) {
                    Pop.error(error)
                }
            }
        }
    },
    components: { KeepModal }
}
</script>


<style lang="scss" scoped></style>