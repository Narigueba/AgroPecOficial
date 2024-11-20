<template>
    <div>
      <label :for="id">{{ label }}</label>
      <input
        :id="id"
        :type="type"
        :value="modelValue"
        @input="$emit('update:modelValue', $event.target.value)"
        :placeholder="placeholder"
        :class="inputClass"
      />
    </div>
  </template>
  
  <script setup>
  import { defineProps, defineEmits } from 'vue'
  
  const props = defineProps({
    modelValue: {
      type: [String, Number], // Aceita tanto String quanto Number
      required: true,
  },
    label: String,
    placeholder: String,
    id: String,
    type: {
      type: String,
      default: 'text',
  },
    inputClass: String,
});
  
  const emit = defineEmits(['update:modelValue'])
  </script>
  
  <style scoped>
  input {
    padding: 8px;
    font-size: 14px;
    border: 1px solid #ccc;
    border-radius: 4px;
  }
  
  input:focus {
    outline: none;
    border-color: #4a90e2;
  }
  </style>
