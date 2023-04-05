<template>
    <div class="card" @click="getKeepById(keep.id)" style="background-position: center; background-size: cover;"
        :style="{ backgroundImage: `url(${keep.img})` }">
        <img class="img-fluid rounded" :src="keep.img" alt="">
        <div class="card-body shadow text-light fw- text-center">
            {{ keep.name }}
        </div>

    </div>
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


<style lang="scss" scoped>
.shadow {
    text-shadow: 1px .5px 2px black;
}
</style>